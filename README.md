# AskGPT
 
This is a console project which allows us to ask ChatGPT about any commands we forgot from the console. Tries to figure out the command and pastes it onto the clipboard.

The linux and windows executables are uploded to github, look for them in the `bin/Debug/net6.0/linux-x64/publish` and `bin/Debug/net6.0/win-x64/publish` folders and check it our yourself.

Uses the text-davinci-003 model.

## Does not contain
- error checking
- caching (so don't spam it please cause it is going to cost me)
- optimisations

## Future plans
- Caching
- error checking and handling

## Usage
You have to set `<RuntimeIdentifier>linux-x64</RuntimeIdentifier>` or `<RuntimeIdentifier>win-x64</RuntimeIdentifier>` depending on what operating system you use.

You can set your path to the executable. So after running the executable

`askgpt "What command do you use if you want to list out all the docker images"` <br>
You can do a Ctr+V and insert `docker images` from the clipboard