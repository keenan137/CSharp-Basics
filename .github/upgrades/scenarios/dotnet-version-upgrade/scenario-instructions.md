# Scenario Instructions

**Scenario**: dotnet-version-upgrade  
**Target Framework**: .NET 10.0 (LTS)  
**Source Framework**: .NET 6.0  
**Repository**: C:\Users\DuPlesK\Downloads\Projects\CSharp-Basics  
**Working Branch**: upgrade-to-NET10  
**Source Branch**: master  

---

## Strategy

**Selected**: All-At-Once

**Rationale**: Single project with low complexity and straightforward upgrade path. Assessment shows no API breaking changes and clear recommended package updates. All projects upgraded simultaneously in one atomic operation.

### Execution Constraints
- Single atomic upgrade operation — all projects updated together
- Validate full solution build after TFM and package updates
- No phased rollout or tier ordering required
- Package updates should be applied across the board in a single pass
- Build and fix compilation errors in one bounded pass, not iteratively

---

## Preferences

### Flow Mode
**Automatic** — Run end-to-end, surface assessments and plans without blocking unless needing clarification

### Technical Preferences
- Target Framework: .NET 10.0 (LTS)
- Upgrade Strategy: All-At-Once (atomic single operation)
- Commit Strategy: Single Commit at End (one atomic upgrade, one commit)

### Execution Style
- Risk Level: Low (straightforward upgrade, no API breaking changes)
- Validation: Build + Test after completion

---

## Key Decisions Log

| Decision | Date | Context |
|----------|------|---------|
| Selected All-At-Once Strategy | 2024 | Single project, low complexity assessment signals |
| Target .NET 10.0 LTS | 2024 | User request for .NET 10 upgrade |

---

## Artifacts
- `assessment.md` — Solution analysis (1 project, low complexity)
- `plan.md` — Upgrade plan (single task: TFM + package updates)
- `tasks.md` — Task status tracker
- `execution-log.md` — Progress record
