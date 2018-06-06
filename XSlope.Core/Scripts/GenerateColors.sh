#!/bin/sh


# Android

file=../../$1/Resources/values/Colors.xml

echo \<\?xml version=\"1.0\" encoding=\"UTF-8\"\?\>\\n\<resources\> > $file

while IFS='' read -r line || [ -n "$line" ]; do
    IFS== read variableName hexValue <<< "$line"
    printf '\t<color name="%s">%s</color>\n' $variableName $hexValue
done <Colors.txt >> $file

echo \</resources\> >> $file


# iOS

file=../../$2/Helpers/Colors.cs

echo using XSlope.iOS.Utils\;\\nusing UIKit\;\\n\\nnamespace $2.Helpers\\n{\\n\\tpublic static class Colors\\n\\t{ > $file

while IFS='' read -r line || [ -n "$line" ]; do
    IFS== read variableName hexValue <<< "$line"

    parts=$(echo $variableName | tr "_" "\n")
    name=""
    for part in $parts
    do
        name+=$(tr '[:lower:]' '[:upper:]' <<< ${part:0:1})${part:1}
    done

    echo \\t\\tpublic static UIColor $name = ColorsUtil.FromHexString\(\"$hexValue\"\)\;
done <Colors.txt >> $file

echo \\t}\\n} >> $file
