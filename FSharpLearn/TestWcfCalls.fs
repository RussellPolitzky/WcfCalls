namespace TestWcfCalls

open Microsoft.VisualStudio.TestTools.UnitTesting    
open Assertions
open System
open System.Diagnostics
open System.ServiceModel
open System.ServiceModel.Channels
open System.ServiceModel.Description
open System.Runtime.Serialization
open System.Timers
open DataContracts
open Assertions

[<TestClass>]
type ``When Making WCF Calls``() =

    [<TestMethod>]        
    member this.``should be able to call time service``() =

        let uri = new Uri("http://localhost:4711")
        let endPointAddress = new EndpointAddress("http://localhost:4711")
        let binding = new BasicHttpBinding()
        let address = new EndpointAddress(uri)

        use channelFactory = new ChannelFactory<ITimeService>(binding, address)
        let client = channelFactory.CreateChannel()
        try 
            let numberCalls = 10000L
            let sw = Stopwatch.StartNew()
            for i in 1L..numberCalls do
                let result = client.GetTime()  // Do this in a loop and add a high res timer for it.
                result |> NotEqualTo  (new DateTime())
            printf "Total time taken is %f milli-seconds per call." ( (float sw.ElapsedMilliseconds) / (float numberCalls))
        finally 
            (client :?> IChannel).Close() 
        ()        

        
