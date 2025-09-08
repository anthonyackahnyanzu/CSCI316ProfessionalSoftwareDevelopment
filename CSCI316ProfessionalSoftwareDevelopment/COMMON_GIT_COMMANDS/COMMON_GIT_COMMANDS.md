# Common Git & GitHub Commands

This file lists the most frequently used Git commands for students learning version control.

---

## 1. Setup

Check Git version:
```bash
git --version
```

Set username and email (first time only):
```bash
git config --global user.name "Your Name"
git config --global user.email "your-email@example.com"
```

Check configuration:
```bash
git config --list
```

---

## 2. Initialize & Clone Repositories

Initialize a local Git repository:
```bash
git init
```

Clone an existing GitHub repository:
```bash
git clone git@github.com:USERNAME/REPO_NAME.git
```

---

## 3. Basic Workflow

Check status of your repository:
```bash
git status
```

Add changes to staging:
```bash
git add .
```

Add a specific file:
```bash
git add file.txt
```

Commit staged changes:
```bash
git commit -m "Meaningful commit message"
```

Push commits to remote repository:
```bash
git push origin main
```

Pull latest changes from remote:
```bash
git pull origin main
```

---

## 4. Branching

Create a new branch:
```bash
git checkout -b feature-branch
```

Switch to an existing branch:
```bash
git checkout main
```

Push a branch to remote:
```bash
git push origin feature-branch
```

Merge a branch into current branch:
```bash
git merge feature-branch
```

---

## 5. Viewing History

View commit history:
```bash
git log
```

One-line summary:
```bash
git log --oneline
```

Compare changes:
```bash
git diff
```

---

## 6. Undoing Changes

Undo changes in working directory:
```bash
git checkout -- file.txt
```

Undo last commit (keep changes staged):
```bash
git reset --soft HEAD~1
```

Undo last commit (discard changes):
```bash
git reset --hard HEAD~1
```

---

## 7. GitHub-specific

Add a remote repository:
```bash
git remote add origin git@github.com:USERNAME/REPO_NAME.git
```

List remotes:
```bash
git remote -v
```

---

## Notes for Students
- Commit messages should describe *why* the change was made, not just *what*.
- Always pull latest changes before starting new work.
- Use branches for features or experiments to avoid breaking the main branch.
