# Riftbound  
**TODO: Brief 1-2 sentence description of the game goes here**

The Unity Editor version used in this project is 2022.3.24f1

## Contributing to the project
### Issues (Where do I start?)
For each feature you are implementing or bug you are fixing, an issue must be created in the [Issues](https://github.com/mohamedghoul/Riftbound/issues) tab. It's not a complicated process at all and realistically only takes 3-5 minutes max. Here's how to do it and some things to keep in mind: 
1. When creating an issue, an appropriate title should be given to it to describe what you are implementing/fixing. For example, if you are tasked with initializing the Unity project, your issue would be title something like "Unity 3D Starter Project".
2. Each issue should have an appropriate description in the following format:
   - A few sentences explaining what is being implemented/fixed
   - A task list (found next to the numbered list and bullet point list on the description toolbar) containing items that should be done to complete the issue
3. Each issue must have appropriate [Labels](https://github.com/mohamedghoul/Riftbound/labels) attached to it too (one "Status" label and one "Type" label). They're super easy to understand and very self explanatory. Would definitely recommend reading through them at least once to understand what they do.
4. Make sure to assign yourself (and anyone else that will be working on this issue as well) to the issue under the "Assignees" section.

You can leave anything that wasn't mentioned in this guide empty for the time being.

### Branches (Where does my work go?)
Now that you created an issue, you can start working on implementing it by going to the "Development" section of your issue, and creating a new branch for your issue. The branch name should be in the following format:  

`issue-type`/`issue-title`

For example, if I'm implementing a title screen feature for the game, I would call my branch `feature/title-screen`. Likewise, if I'm fixing a missing monster audio problem, I would call my branch `bug/missing-monster-audio`.

By creating a branch, you're grabbing a copy of the latest version of the [main](https://github.com/mohamedghoul/Riftbound) branch, that you can start work on without affecting anyone else's work. This is the best way to allow us to collaborate on our project.

`Note:` Don't forget to commit your work frequently to your branch. Committing all of your finished work in one huge commit makes it infinitely harder to debug, especially for the person who will be reviewing your work later, which brings us to the next section...

### Merge requests (What happens when I'm done with my work?)  
Once you're done working on your issue, you'll need to merge the branch you worked on to the [main](https://github.com/mohamedghoul/Riftbound) branch, and in order to do that, you'll need to create a [merge request](https://github.com/mohamedghoul/Riftbound/pulls). Here's how to do it:

1. Make sure you committed and pushed all of your latest work to your branch
2. Head over to [Pull Requests](https://github.com/mohamedghoul/Riftbound/pulls) and click on "New pull request"
3. The base branch is always [main](https://github.com/mohamedghoul/Riftbound), while the compare branch is the branch you want to merge.
4. You need to assign yourself to the pull request and add the other group members as reviewers, so they can review your work. 
   - A pull request cannot be merged without at least 1 reviewer's approval.
   - A reviewer should switch to the branch in the pull request, test the Unity project and add any comments they have to the pull request. Approval to merge should only be given if all the requirements are met.
5. The description should ideally be a short description of what was implemented and what needs reviewing, along with anything the reviewer should keep in mind.
6. Once approval is given, the branch can be merged into [main](https://github.com/mohamedghoul/Riftbound), and the issue can be closed with the tag "Status: Completed".

This just about covers everything you need to know about contributing to the project. If you have any questions, feel free to ask them in the group WhatsApp chat. Good luck!

## Authors  
Mohamed Ghoul [@mohamedghoul](https://github.com/mohamedghoul)
