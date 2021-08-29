#addin nuget:?package=Cake.Docker
var target = Argument("target", "Docker-Build");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .WithCriteria(c => HasArgument("rebuild"))
    .Does(() =>
{
    CleanDirectory($"./CarteiraPetwebApp/bin/{configuration}");
});

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreBuild("./CarteiraPetwebApp.sln", new DotNetCoreBuildSettings
    {
        Configuration = configuration,
    });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreTest("./CarteiraPetwebApp.sln", new DotNetCoreTestSettings
    {
        Configuration = configuration,
        NoBuild = true,
    });
});

Task("Docker-Build")
.Does(() => {   
    DockerRun("mcr.microsoft.com/mssql/server", "docker run" );
});

///////////////////////////////////////////////////////////////////////////////
//setup infra
///////////////////////////////////////////////////////////////////////////////
Task("DrySetup")
    .Description("Setup infra")
    .Does(() => {
        RunTarget("RunMongo");
        RunTarget("RunSqlServer");        
});

Task("Teardown")
    .Description("Clean-up test resources")
    .Does(() => {
        RunTarget("RemoveSqlServerContainer");
        RunTarget("RemoveMongoContainer");
});

///////////////////////////////////////////////////////////////////////////////
// TASKS containerSqlServer
///////////////////////////////////////////////////////////////////////////////

const string containerSqlServer = "SqlServer";
Task("RunSqlServer")
    .Description("Roda o Docker com SqlServer")
    .Does(() => {
        DockerRun(new DockerContainerRunSettings() {
              Detach = true,
              Name = containerSqlServer,
              Publish = new [] {"1433:1433"},
              Rm = true,
              Env = new [] {
                 "ACCEPT_EULA=Y",
                 "SA_PASSWORD=YourStrong@Passw0rd"
              }
        },
        "mcr.microsoft.com/mssql/server:2017-latest", "");
});

Task("RemoveSqlServerContainer")
    .Description("Remove contêiner Docker com SqlServer (caso exista)")
    .Does(() => {
        DockerRm(new DockerContainerRmSettings() { Force = true }, containerSqlServer);
    });

Task("StartSqlServer")
    .Description("Inicia o Docker com SqlServer")
    .Does(() => {
        DockerStart(new DockerContainerStartSettings(), containerSqlServer);
});

//////////////////////////////////////////////////////////////////////////////
// TASKS containerMongo
///////////////////////////////////////////////////////////////////////////////

const string containerMongo = "mongo";
Task("RunMongo")
    .Description("Roda o Docker com Mongo")
    .Does(() => {
        DockerRun(new DockerContainerRunSettings() {
              Detach = true,
              Name = containerMongo,
              Publish = new [] {"27017:27017"},
              Rm = true,
              Env = new [] {
                 "PUID=1000",
                 "PGID=1000"
              }
        },
        "mongo", "");
});

Task("RemoveMongoContainer")
    .Description("Remove contêiner Docker com Mongo (caso exista)")
    .Does(() => {
        DockerRm(new DockerContainerRmSettings() { Force = true }, containerMongo);
    });

Task("StartMongo")
    .Description("Inicia o Docker com Mongo")
    .Does(() => {
        DockerStart(new DockerContainerStartSettings(), containerMongo);
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
