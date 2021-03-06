# IoT.Display.UWP
This is a platform specific adapter for [IoT.Display](https://github.com/serhiiz/IoT.Display) which enables it to run on Raspberry Pi under .Net Framework/Mono. It's based on [RaspberrySharp](https://github.com/JTrotta/RaspberrySharp).

[![NuGet version (IoT.Display.RaspberrySharp)](https://img.shields.io/nuget/v/IoT.Display.RaspberrySharp.svg?style=flat-square)](https://www.nuget.org/packages/IoT.Display.RaspberrySharp/)

# Code example
```F#
open IoT.Display
open IoT.Display.RaspberrySharp
open IoT.Display.Layout
open IoT.Display.Devices
open IoT.Display.Devices.SSD1306

[<EntryPoint>]
let main _ =
    use display = SSD1306Factory.createAtI2C1 SSD1306Factory.ssd1306Address3C :> ISSD1306

    [
        setChargePumpOn 
        flipVertically 
        flipHorizontally 
    ] 
    |> List.iter display.SendCommand

    dock [] [
        dock [Dock Dock.Top] [
            text [Dock Dock.Left; Margin (thicknessSame 2)] "TL"
            text [Dock Dock.Right; Margin (thicknessSame 2)] "TR"
        ]
        dock [Dock Dock.Bottom] [
            text [Dock Dock.Left; Margin (thicknessSame 2)] "BL"
            text [Dock Dock.Right; Margin (thicknessSame 2)] "BR"
        ]
        text [Dock Dock.Fill; HorizontalAlignment HorizontalAlignment.Center; VerticalAlignment VerticalAlignment.Center] "Welcome!"
        
    ]
    |> renderToDisplay display
    
    turnOn |> display.SendCommand
    
    0
```

# License
IoT.Display.RaspberrySharp is licensed under the [MIT license](LICENSE).
