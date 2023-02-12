# Workspace notes

## Release 2

February 12th

We have ended up choosing to make an ASP.net backend in C#. The frontend is made in React with Typescript.
Our considerations have been based on choosing something that is currently widely used and with a large community. 

### Backend

We have chosen ASP.NET and C# because they are powerful, flexible, and efficient technologies for back-end development, and their combination of efficient performance, scalability, rich development tools, and large community make them a popular and effective choice for building robust and scalable back-ends.

Most group members haven't developed in these besides what we have tried during our education at ITU. In any case it will be beneficial for the team members to try this combination in a DevOps setting.

### Frontend

React is for the fifth year in a row the most wanted framework according to [stackoverflow](https://survey.stackoverflow.co/2022/#most-loved-dreaded-and-wanted-webframe-want). It has a continous large userbase, good interoperability and high performance.

We have chosen Typescript since it is the fastest growing programming language according to Jetbrains [State of Developer Ecosystem 2022](https://www.jetbrains.com/lp/devecosystem-2022/). 
It is also in the current state a widely used programming language which ensures that many developers are capable of taking over this part of the project.

None in the group have tried to develop in this combination before but have shown interest in it.

## Release 1

February 5th

The files were using an outdated version of python. To ensure it would work on modern systems we updated it to be able to run for python3.

The following changes was therefore done:

- minitwit.py was updated to run for python3 and the location of the database has been changed.
- requirements.txt has been added with relevant requirements and version numbers marked.
- control.sh has been updated to the new python.
- The database has been added as minitwit.db. This was not possible due to the gitignore that was ignoring .db files.
