# Welcome to the devUps contributing guide

To get more information about the project, read the [README](README.md).

This guide will show you how to contribute to the project.

## Which repository setup will we use?

All files for the project is stored in the repository *devUps*, this means both files for the frontend and backend.

All relevant files for the ASP.net backend is located in the folder *minitwit-backend*.

All relevant files for the React frontend is located in the folder *minitwit-frontend*.

## Which branching model will we used?

This project uses a [GitFlow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow) approach to the branching model.

The *main* branch will be used to create branches for releases. These release-branches have tags with corresponding version numbers.

The *dev* branch is used to integrate features. That means that a new feature is branched out from the dev-branch.
These branches should contain the naming scheme `\issueNumber_description` where the description is so for example `001_good_name`

Hotfixes can be created

### Rebasing or squashing

We recommend that you do not rewrite history by rebasing or squashing your commits.
The main reason is that it remains visible in the history who did what and when.

## Which distributed development workflow will we use?



## How do we expect contributions to look like?

### Issues

#### Create issues

If you have found an issue or have a feature request for this project, feel free to make an issue about it.
However, before adding it, remember to search if there already exists an open issue about it.
We will use the issue to discuss the relevance of it and add it to our roadmap if we deem it fit.
Remember to add appropriate labels to it.

#### Solve issues

If you wanna help solve a current issue please feel free to do so.
you can use `labels` to find specific issues.
When you are done create a pull request with the issue.

### Pull requests

This project uses pull requests to review suggested changes to the project.
When creating one remember to use the template in the repository to ensure relevant info is given.
When a PR is merged it will highly likely be deployed within a week.

## Who is responsible for integrating/reviewing contributions?

Both the *main* and *dev* branch are protected with a rule that at least one collaborator should approve a pull request before it can be merged into the branch .
Every collaborator on the project can review pull request and integrate them.
