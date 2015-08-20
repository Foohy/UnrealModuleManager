# Unreal Engine Module Manager
Easy to use tool for generating new modules for the Unreal Engine.

### What does it do?
When you open this application with a project's .uproject file, it will quickly scan to see what modules already exist.

![Module List](http://i.imgur.com/PNvkoRt.png)


The new module dialog shows a list of options to pre-set into the new module, including name, dependencies, loading phase, and module type.

![New Module Settings](http://i.imgur.com/PvqSNb9.png)


When you click 'Create', it will create all the files in your source directory, optionally appending an entry to your project's .uproject file with the new module's information. 

![The generated file structure](http://i.imgur.com/9MRHOT0.png)

### Why?
In order to create a new module for UE4, it involves a lot of tedious file placement and naming, incredibly prone to human error. This application lets you generate a brand new module already set up with a given name so you can start writing the code that matters quicker.

When you can create modules easily
  - It gives more reason to modularize your codebase
  - Pinpoint bugs to come from specific modules
  - Clean up code
    

### This seems pretty dang specific
yeah but it's pretty dang useful too so watch it bub.

## Requirements
The executable is compiled for 64bit, and .Net framework 4.5. So those two things are pretty much it.

#### Third Party Libraries
I use Newtonsoft's Json.NET library for parsing the uproject definition, so if you'd like to compile it, you'll need to grab a dll or compile from the source
http://www.newtonsoft.com/json
