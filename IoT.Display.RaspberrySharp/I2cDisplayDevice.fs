namespace IoT.Display.RaspberrySharp

module I2cDisplayDevice =

    open System
    open IoT.Display.Devices
    open RaspberrySharp.IO.InterIntegratedCircuit    

    type I2cDisplayDevice (driver:I2cDriver, address) = 
        let connection = driver.Connect(address)
        interface IDevice with 
            member __.Write(data) =
                connection.Write data
        interface IDisposable with
            member __.Dispose() = 
                driver.Dispose() 