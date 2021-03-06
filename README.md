# Reference Manager
*Solidworks PDM File reference manager*

The Reference Manager was a quick fix to a problem my company had regarding our move from a Windows Filesystem to the Solidworks Managed filesystem PDM.
Managing file references is a horrible task, and (at least at the time) there was no way of re-referencing files recently moved into our filesystem.

We had three problems which needed solving:
* Re-referencing our legacy data
* Selecting the newest Issues (files without Issue no.s in the filename)
* Preventing file duplication

## How does it manage Filenames?
### Managing Issue/Revision numbers
A couple of years ago we moved from standard numeric revision (rev 1,2,3,..) to a custom system with a backwards date (rev 190528 would be the date 19-05-28). I needed to ensure that files priotitized the latest revision files, which ultimately turned out to be quite simple:

From newest at the top, to oldest at the bottom:
1. [190528]
2. [181205]
3. [180414]
4. [4]
5. [2]
6. [1]

As you can see from this list, newer revisions are always numerically larger than older revisions - therefore this is the system it uses to determine the latest revision

### Managing Filename Variations
*It works with two filename variations:*

1. \<filename>.\<extension>
2. \<filename>[\<issue>].\<extension> eg. 'Filename[180924].sldprt'

It looks for files in a specific order:

1. An exact match of Variation 1
2. An exact match of Variation 2, with the highest value \<issue> as an integer
3. An exact match of Variation 2, with any value \<issue> as an integer

This system implementing this prioritization assumes the following rules:

* There **should** only ever be one live copy of a file at a time - this excludes legacy copies
* All files required for work **need** to follow **Filename Variation 1**
* All files required for work **need** to have an "Issue" property in their metadata
* Files not required for work (legacy files) can be any of the other 2 filename variations listed

## Known bugs
* Sometimes the dropdowns in the Table glitch and cannot be clicked or hovered over. I think this is because the program is trying to insert an invalid value from a filename or reference. Haven't fixed this yet
* After re-referencing, mates within assemblies can sometimes be broken - often due to small changes in different models. Our companies legacy filesystem is a mess however, and certainly doesn't help this.
* Error in IDE: Cannot open .resx file - not really a bug but still a problem. Right click on the two files in Explorer and make sure that "Unblock" is checked

## Improvements I want to make but haven't got round to yet
* Recursive Re-referencing
   * By this I mean the option of re-referencing referenced assemblies, parts, and drawings. Currently only the selected files are re-referenced. 
* Adaptive Issue no. functionality
   * Allowing the user to customize how their filenames & issue no's are setup - so that it's useful outside of the few companies that might actually use the noted system.

## Notes & Requirements
* Requires a Solidworks PDM License key. 
  * You will need to contact your reseller for this.
  * License key should be ~1300 characters long, and generally begins with your company name
* Built to work with EPDM Version 18 Service pack 2. Should work with any Version 18 Service pack. Might work with Future versions. Probably won't work with older versions.
