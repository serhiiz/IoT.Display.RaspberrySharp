open IoT.Display
open IoT.Display.RaspberrySharp
open IoT.Display.Graphics
open IoT.Display.Primitives
open IoT.Display.Layout
open IoT.Display.Devices
open IoT.Display.Devices.SSD1306

let init (display:ISSD1306) = 
    [
        setChargePumpOn 
        flipVertically 
        flipHorizontally 
    ] 
    |> List.iter display.SendCommand

    dock [][] |> renderToDisplay display
    turnOn |> display.SendCommand

let render (display:ISSD1306) =
   
        DeactivateScroll |> display.SendCommand

        let margin = Margin (thicknessSame 2)
        
        dock [] [
            dock [Dock Dock.Top] [
                text [Dock Dock.Left; margin] "TL"
                text [Dock Dock.Right; margin] "TR"
            ]
            dock [Dock Dock.Bottom] [
                text [Dock Dock.Left; margin] "BL"
                text [Dock Dock.Right; margin] "BR"
            ]
            text [Dock Dock.Fill; HorizontalAlignment HorizontalAlignment.Center; VerticalAlignment VerticalAlignment.Center] "Welcome!"
            
        ]
        |> renderToDisplay display

        let hConfig = {
            Direction = ScrollDirection.Right; 
            StartPage = Page0; 
            EndPage = Page1; 
            Interval = ScrollInterval.Frames64
        }

        let vConfig = {
            Offset = 2uy; 
            StartRow = 24uy; 
            Height = 16uy;
        }

        SetupScroll (hConfig, Some vConfig) |> display.SendCommand
        ActivateScroll |> display.SendCommand


[<EntryPoint>]
let main argv =
    use display = SSD1306Factory.createAtI2C1 SSD1306Factory.ssd1306Address3C
    init display
    render display
    0