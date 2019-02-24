namespace IoT.Display.RaspberrySharp

module SSD1306Factory =

    open RaspberrySharp.IO.GeneralPurpose;
    open RaspberrySharp.IO.InterIntegratedCircuit;
    open IoT.Display.Devices.SSD1306

    [<Literal>]
    let ssd1306Address3C = 0x3C

    [<Literal>]
    let ssd1306Address3D = 0x3D

    let createAtI2C (sdaPin:ProcessorPin) (sclPin:ProcessorPin) address = 
        let driver = new I2cDriver(sdaPin, sclPin)
        let i2cDisplayDevice = new I2cDisplayDevice.I2cDisplayDevice(driver, address)
        new SSD1306(i2cDisplayDevice)

    let createAtI2C1 address = 
        let sdaPin = ProcessorPin.Gpio02;
        let sclPin = ProcessorPin.Gpio03;
        createAtI2C sdaPin sclPin address