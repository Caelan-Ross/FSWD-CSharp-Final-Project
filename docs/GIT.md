# 📝 Git Branch Naming Conventions
This document is to help us standardize how we will be working with Github on this project as a team by creating some conventions for naming and workflow.

A high level summary of our workflow is as follow:
- Please use `alpha` branch as a starting point to do any work. From here, you may create a `feature` or `bug` branch. Merge back into `alpha` when done and test.
- At each major stage of our development, please merge `alpha` back into `beta`.
- After testing is done extensively and we are ready to submit, we can merge `beta` back into `main`



# 🖥️ Code Flow Branches
**Main (*main*)**

This is the main branch that will be submitted as our final version release.

**Beta (*beta*)**

This branch will be used to do any final testing before merging into the `main` branch for submittal.

**Alpha (*alpha*)**

This is the development branch. From here, please make `feature` branches to work on and then merge back into `alpha` when complete.

# 🌿 Temporary Branches
**Feature (*feature/feature-name*)**

When working on a new feature, create a feature branch and later merge back into `alpha.`

Examples:
```
   feature/integrate-MUI
   feature/CRUD-setup
```

**Bug Fix (*bugfix/bug-name*)**
Similar to `feature` branch, create `bugfix` branches to work on any bugs you may find and then merge back into `alpha` when ready.
```
   bugfix/export-inventory-crash
   bugfix/delete-vehicle
```