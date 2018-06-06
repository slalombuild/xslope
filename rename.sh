#!/bin/bash
#================================================================
# HEADER
#================================================================
#%
#% DESCRIPTION
#%    Will search through your project directory and rename project based on input
#%    Note: Please run this script BEFORE building the project to prevent unexpected behavior
#%
#% EXAMPLES
#%    ${SCRIPT_NAME} NewProjectName (note: OldProjectName will default to STARTER_APP)
#%    ${SCRIPT_NAME} OldProjectName NewProjectName
#%
#================================================================
# END_OF_HEADER
#================================================================

export LANG=C

  display_usage() {
    # displays how-to use message
    echo -e "Usage:\t$0 [NewProjectName]"
	  echo -e "\t$0 [OldProjectName] [NewProjectName]";
	}

  confirm_usage() {
      # call with a prompt string or use a default
      echo -e "\033[34m"
      read -p "Do you wish to replace all above instances of '"$2"' to '"$3"' in the following files? [y/N] " response
      echo -e "\033[00m"
      response=${response:-1}
      case "$response" in
        [yY][eE][sS]|[yY])
          eval $1=true
        ;;
        *)
          eval $1=false
        ;;
      esac
  }

  # takes a single string param to search for
  display_search(){
    # prints all instance of the search string to user
    # Note: this can be used for debug
    echo -e "\033[2m"
    grep -inR "$1" --include=*.{cs,csproj,plist,sln,md,sh,xml,xib} .
    echo -e "\033[00m"
  }

  # takes two strings to find and replace
  replace() {
    echo -e "\033[2m[Searching and replacing $1 with $2]\033[00m"
    find . \( -name '*.cs' -o -name '*.csproj' -o -name '*.plist' -o -name '*.sln' -o -name '*.md' -o -name '*.sh' -o -name '*.xml' -o -name '*.xib' \) -print0 | xargs -0 sed -i '' "s/$1/$2/g"

  }

  # Takes two strings to find and replace
  # Note: Makes assumption of the project structure 
  rename_files() {
    echo -e "\033[2m[Renaming files and folders from $1 to $2]\033[00m"
    mv "$1.sln" "$2.sln"  # rename the sln file
	mv "$1.userprefs" "$2.userprefs"  # rename the userprefs file
    mv "$1.Core" "$2.Core"  # rename the Core project
    mv "$1.Core.Tests" "$2.Core.Tests"  # rename the Core.Tests project
    mv "$1.Droid" "$2.Droid"  # rename the Droid project
    mv "$1.iOS" "$2.iOS"  # rename the iOS project
    find . -name '*.csproj' -type f -exec bash -c 'mv $0 ${0//'$1'./'$2'.}' {} \; #rename csproj files   
  }

  # usage check
  if [  $# -le 0 ]
  then
    display_usage
    exit 1
  fi

  # handle usage
  existingName=$1
  newName=$2
  if [ -z "$2" ]
  then
    existingName="STARTER_APP"
    newName=$1
  fi

  # checks if we need to rename files
  if [ "$existingName" == "$newName" ]
  then
    echo "Existing project already uses that name"
    exit 1
  fi

  # display_search $existingName
  confirm=false
  confirm_usage confirm $existingName $newName

  # after user confirmation, applies new name change
  if [ "$confirm" = true ]; then
      rename_files $existingName $newName
      replace $existingName $newName
  fi

  echo -e "\033[2m[setup complete]\033[00m"
exit
