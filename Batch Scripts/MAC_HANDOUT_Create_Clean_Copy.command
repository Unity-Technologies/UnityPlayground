#!/bin/sh

cd "${0%/*}"
cd ..

#Set project specific variables
PROJNAME="Playground Project"
FINALPATH="$root_vol$HOME/Desktop/$PROJNAME"

#Copy relevant folders to desktop (changes with each project)
ditto "PlaygroundProject/Assets" "$FINALPATH/Assets"
ditto "PlaygroundProject/ProjectSettings" "$FINALPATH/ProjectSettings"

#Copy relevant loose files to desktop (changes with each project)
