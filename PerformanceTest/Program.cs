using System.Net.Http;
using NBomber.CSharp;
using NBomber.Http.CSharp;

using var httpClient = new HttpClient();

const int TEST_DURATION = 60;

var controllerScenario = Scenario.Create("controller_escenario", async context =>
{
    var request = Http.CreateRequest("GET", "http://localhost:5001/api/users/1").WithHeader("Accept", "application/json");
    return await Http.Send(httpClient, request);
})
.WithWarmUpDuration(TimeSpan.FromSeconds(5))
.WithLoadSimulations(Simulation.KeepConstant(24, TimeSpan.FromSeconds(TEST_DURATION))
);

var minimapAPIsScenario = Scenario.Create("minimal_apis_escenario", async context =>
{
    var request = Http.CreateRequest("GET", "http://localhost:5002/api/users/1").WithHeader("Accept", "application/json");
    return await Http.Send(httpClient, request);
})
.WithWarmUpDuration(TimeSpan.FromSeconds(5))
.WithLoadSimulations(Simulation.KeepConstant(24, TimeSpan.FromSeconds(TEST_DURATION))
);

var golangScenario = Scenario.Create("golang_scenario", async context =>
{
    var request = Http.CreateRequest("GET", "http://localhost:5003/api/users/1").WithHeader("Accept", "application/json");
    return await Http.Send(httpClient, request);
})
.WithWarmUpDuration(TimeSpan.FromSeconds(5))
.WithLoadSimulations(Simulation.KeepConstant(24, TimeSpan.FromSeconds(TEST_DURATION))
);

var rustScenario = Scenario.Create("rust", async context =>
{
    var request = Http.CreateRequest("GET", "http://localhost:5004/api/users/1").WithHeader("Accept", "application/json");
    return await Http.Send(httpClient, request);
})
.WithWarmUpDuration(TimeSpan.FromSeconds(5))
.WithLoadSimulations(Simulation.KeepConstant(24, TimeSpan.FromSeconds(TEST_DURATION))
);


NBomberRunner
    .RegisterScenarios(controllerScenario, minimapAPIsScenario, golangScenario, rustScenario)
    .Run();
