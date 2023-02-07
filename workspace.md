# Workspace notes

## Release 1

The files were using an outdated version of python. To ensure it would work on modern systems we updated it to be able to run for python3.

The following changes was therefore done:

- minitwit.py was updated to run for python3 and the location of the database has been changed.
- requirements.txt has been added with relevant requirements and version numbers marked.
- control.sh has been updated to the new python.
- The database has been added as minitwit.db. This was not possible due to the gitignore that was ignoring .db files.
