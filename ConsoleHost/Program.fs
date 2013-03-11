open System
open System.ServiceModel
open System.ServiceModel.Description
open Services


// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    use host = new ServiceHost(typeof<TimeService>, new Uri("http://localhost:4711"))
    host.Description.Behaviors.Add(new ServiceMetadataBehavior(HttpGetEnabled = true));
    host.Open()

    printfn "Service is up'n running at %s" (host.Description.Endpoints.[0].Address.ToString())
    printfn "Press any key to shut down service"
    Console.ReadKey() |> ignore
    0

    

