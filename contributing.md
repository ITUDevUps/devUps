# Welcome to the devUps contributing guide

To get more information about the project, read the [README](README.md).

This guide will show you how to contribute to the project.

## Which repository setup will we use?

All files for the project is stored in the repository *devUps*.

All relevant files for the ASP.net backend is located in the folder *minitwit-backend*.

All relevant files for the react frontend is located in the folder *minitwit-frontend*.

## Which branching model will we use?

This project uses a [GitFlow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow) approach to the branching model.

The *main* branch will be used to create releases. These releases can be seen as tags with corresponding version numbers.

The *dev* branch is used to integrate features. A new feature is branched out from this branch.
These branches should contain the naming scheme \<issueNumber-description\> where the description is so for example `001-good-name`

### Rebasing or squashing

We recommend that you do not rewrite history by rebasing or squashing your commits.
The main reason is that it remains visible in the history who did what and when.

## Which distributed development workflow will we use?



## How do we expect contributions to look like?


## Who is responsible for integrating/reviewing contributions?

Both the *main* and *dev* branch are protected with a rule that at least one collaborator should approve a pull request before it can be merged into the branch .
Every collaborator on the project can review pull request and integrate them.
