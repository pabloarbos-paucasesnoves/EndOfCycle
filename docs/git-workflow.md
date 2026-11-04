# Git Workflow

## Ramas

- `main`: solo versiones estables (cada hito completado).
- `dev`: trabajo diario.
- `feature/nombre-tarea`: una por tarea, creada desde `dev`.
- `fix/nombre`: para correcciones.

## Ciclo de cada tarea

1. `git switch dev && git pull`
2. `git switch -c feature/nombre-tarea`
3. Trabajar, hacer commits y `git push -u origin feature/nombre-tarea`
4. Merge a `dev` al terminar la tarea.

## Cierre de hito

Merge de `dev` a `main` y creación de un tag nuevo.

## Versionado (SemVer, fase 0.x)

- `v0.1.0-alpha`: punto de partida del proyecto.
- `v0.X.0`: cada hito completado (Hito 1 = `v0.2.0`).
- `v0.X.Y`: correcciones.
- `v1.0.0`: versión completa.
- No hay tags por entrega: se entrega siempre el último tag.

## Reglas extra

- Dos ramas no deben modificar la misma escena (`.unity`) a la vez, para evitar conflictos de merge.
- Git LFS activo para binarios pesados y `.gitignore` de Unity configurado.
- Los cambios automáticos de Unity que no ha hecho la persona (por ejemplo, reserializaciones de `ProjectSettings` o de ajustes de URP) no se commitean: se descartan con `git restore`.

## Conventional Commits (sin ámbito)

Formato: `tipo: description in English`

| Tipo | Cuándo |
|---|---|
| `feat` | Algo nuevo en el juego (escena, mecánica, UI) |
| `fix` | Corregir un fallo |
| `refactor` | Reorganizar código sin cambiar el comportamiento |
| `docs` | Documentación |
| `chore` | Mantenimiento: configuración, Build Settings, `.gitattributes` |
| `style` | Formato del código, sin cambios de lógica |
| `test` | Pruebas |

### Normas

- Mensaje en inglés, en imperativo, sin punto final y, idealmente, de menos de 72 caracteres.
- Un commit por cambio lógico; no mezclar tareas distintas.

### Ejemplos (Hito 1)

```
feat: create Level1 scene with light and camera
feat: add long ground with collider
feat: add lateral player movement with A/D and arrows
feat: add automatic forward movement on Z axis
feat: clamp player position to ground width
feat: add camera follow with editable distance and height
feat: create MainMenu scene with Canvas and EventSystem
feat: add Play button that loads Level1
chore: add MainMenu and Level1 to Build Settings
chore: normalize line endings with .gitattributes
docs: add hito-1 tasks and acceptance criteria
```
