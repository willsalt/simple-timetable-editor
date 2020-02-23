# Simple Timetable Editor
An editor for creating timetables for simple railway networks

I started creating this app in 2016.  I'm a volunteer at a heritage steam railway, and was unhappy about the format of the internal "working timetables" that we were using internally, which were produced in Excel.  The working timetable is the timetable used on a railway by operations staff, containing a bit more information than the timetable shown to the public.

The aims of the project were and are:
* To replicate all of the information shown on the existing working timetables used on our railway
* To include a "train graph" that shows line occupation graphically
* To produce output with formatting that more closely resembles a printed British Railways working timetable from circa 1950.
* To make it easy to enter and edit working timetables

Arguably the current state of the app achieves all of those aims apart from the last one.

## Dependencies

The program is currently a Windows Desktop app written using .NET Framework 4.7.2 and Windows Forms.

It depends on the following external libs:
* [NLog](https://nlog-project.org/) - v4.6.8
* [PDFSharp](http://www.pdfsharp.net/) - v1.50
* [SharpYaml](https://github.com/xoofx/SharpYaml) - v1.6.5

The unit test projects also depend on:
* [Moq](https://github.com/moq/moq4) - v4.13.1

## Current state of the project

Although the app currently meets most of its stated aims, there is still a fair amount of work to do.  Its performance is very bad when carrying out certain operations, due to how it uses `DataGridView` components.  I suspect the internal data model could do with a rewrite.

The PDF export subsystem currently depends on PDFSharp, but I am wary of the long-term health of that project given their website still says their code is hosted on Codeplex.  Given there is not much choice for good PDF-writing software, my long-term aim is to be able to write PDFs from scratch, then spin off the PDF export subsystem into its own separate library.

Logging is currently handled by NLog.  Following a recommendation from a very experienced .NET engineer I considered porting the logging code over to [Serilog](https://serilog.net/), but although it has a number of benefits it does not currently support the run-time reconfiguration features of NLog.

The program currently only handles simple timetables.  Branching networks are not supported.  The current version does now handle trains that overtake each other, but support is limited.

The program is partially unit-tested, but test coverage is not fantastic and should be improved.

## Short-to-medium-term aims

* Fix various small bugs.
* Port more of the program to .NET Core (and .NET 5 when it is released).
* Make data input easier.
* Improve "editable train graph" functionality.
* Handle some bugs around trains overtaking other trains, particularly how this interacts with editing the train graph.
* Support trains that are in transit at midnight properly.
* Remove reliance on third-party libraries for PDF generation.
* Improve test coverage rate.
* Improve documentation.
