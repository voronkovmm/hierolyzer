# Scene Headers

Turn any GameObject into a colored, styled section divider in the Hierarchy window, so large scenes stay easy to scan.

- Editor-only by default (tagged `EditorOnly`) and stripped from the hierarchy on build via a dedicated build step.
- Creating, converting and reverting headers integrates with Unity's Undo system.

## Usage

Right-click in the Hierarchy window → `Hierolyzer` → `Headers`:

- **Create** - adds a new header GameObject.
- **Convert** - turns the selected GameObject into a header.
- **Revert** - removes the header component and restores the object's tag.

Header appearance (color, text color, font style, alignment) is configured per-object in the Inspector on the `Hiero Header` component.

## Architecture

- `Runtime/` - `HieroHeader`, the MonoBehaviour marker component (works without the editor).
- `Editor/HierarchyHeaders/` - draws headers in the Hierarchy window.
- `Editor/BuildProcessors/` - `BuildProcessor` is a single entry point that walks the scene hierarchy once and runs a set of `IHierarchyBuildStep` handlers (currently `HeaderStripStep`) against every GameObject, so future build-time steps don't each re-traverse the scene.
