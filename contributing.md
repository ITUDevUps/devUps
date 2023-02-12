# Welcome to the devUps contributing guide

To get more information about the project, read the [README](README.md).

This guide will show you how to contribute to the project.

## Which repository setup will we use?

All files for the project is stored in the repository *devUps*, this means both files for the frontend and backend.

All relevant files for the ASP.net backend is located in the folder *minitwit-backend*.

All relevant files for the React frontend is located in the folder *minitwit-frontend*.

## Which branching model will we used?

This project uses a [GitFlow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow) approach to the branching model.

This means there exist the following types of branches:

- release: called *main*
- development: called *dev*
- features: prefixed with issue number
- hotfix: prefixed with "hotfix/"

The *main* branch will be used to create branches for releases. These release-branches have tags with corresponding version numbers.

The *dev* branch is used to integrate features. That means that a new feature is branched out from the dev-branch.
These branches should contain the naming scheme "*issueNumber_description*" where the description is so for example "*001_good_name*"

Hotfixes are created if there are bugs that needs to be fixed quikckly. The naming scheme is prefixed with "*hotfix/*". Example for this is "*hotfix/login_page*".
If the bug can wait it should be created as an issue and fixed in a feature branch.

### Rebasing or squashing

We recommend that you do not rewrite history by rebasing or squashing your commits.
The main reason is that it remains visible in the history who did what and when.

## Which distributed development workflow will we use?

A developer creates a branch for their own issue.
In general there should only be one developer per branch to reduce merge conflicts and other issues.
If two or more developers are working on the same are of the code they communicate internally on deadlines and distribution of work to avoid conflicts.

A developer shall merge the dev branch into their branch before making a pull request towards the dev-branch.

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
When you are done create a pull request with the issue (see section beneath).

### Pull requests

This project uses pull requests to review suggested changes to the project. Do the following steps:
- Fill out the template to ensure relevant info is given. This help reviewers understand what are being suggested and what the purpose of the PR is.
- Link the PR to a relevant issue
- If there are anything that should be changed in the PR it will be requested in the form of "suggested changes" or "pull request comments".
- As you resolve these changes mark each conversation as resolved.

When a PR is merged it will highly likely be deployed within a week.

## Who is responsible for integrating/reviewing contributions?

Both the *main* and *dev* branch are protected with a rule that at least one collaborator should approve a pull request before it can be merged into the branch .
Every collaborator on the project can review pull request and integrate them.
