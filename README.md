# DOOM.inc

**Henrique Leonardo Bento Afonso — Nº 15799**

Unity version: 6000.3.9f1

---

## Resumo do jogo e funcionabilidades

**DOOM.inc** é um jogo First Person Shooting desenvolvido em Unity, inspirado nos clássicos do género. O jogador percorre três níveis, enfrentando inimigos de dano corpo-a-corpo e inimigos atiradores, recolhendo munição e vida, com o objetivo de chegar ao final de cada nível.

### Funcionalidades implementadas

- **Movimentação do jogador**: movimento com WASD/setas, salto com a barra de espaço, e look-around com o rato.
- **Sistema de armas**: duas armas disponíveis (pistola e metralhadora), com troca via scroll do rato, recoil visual, flash de disparo e efeitos de impacto.
- **Sistema de munição**: contagem de balas por arma, com som de arma vazia e pickups de munição espalhados pelos níveis.
- **Sistema de saúde**: texto numérico, flash vermelho ao receber dano, e pickups de cura.
- **Inimigos**:
  - Inimigo corpo-a-corpo: persegue o jogador na proximidade e causa dano ao contacto.
  - Inimigo atirador: dispara projéteis contra o jogador quando dentro do raio de visão.
  - Ambos usam NavMesh para navegação inteligente.
  - Efeito de morte com partículas, som e possível drop de item.
- **Sistema de kills**: contador de inimigos eliminados no ecrã.
- **Cenas e menus**: menu inicial, menus de nível completo, Game Over, e ecrã de vitória final.
- **Efeitos visuais e sonoros**: flash de dano, partículas de morte, animação de flutuação e rotação nos pickups, sons de tiro, dano, morte, e recolha de itens.
- **Mudança de câmara**: alternar entre câmara em primeira pessoa e câmara estática com a tecla **C**.
- **Instruções temporárias**: painéis de instruções/tutorial que aparecem automaticamente no início de uma cena e desaparecem após um tempo definido.

---

## Jogabilidade, como jogar

### Controlos

| Ação | Tecla / Input |
|------|---------------|
| Mover | WASD ou Setas direcionais |
| Olhar em volta | Movimento do rato |
| Saltar | Barra de espaço |
| Disparar | Clique esquerdo do rato |
| Trocar de arma | Scroll do rato |
| Mudar câmara | Tecla **C** |

### Objetivo

- Avança pelos três níveis eliminando inimigos.
- Recolhe **munição** (caixas de balas) e **packs de vida** para sobreviver.
- Chega ao item de fim de nível para progredir.
- Elimina o Boss no nível final para vencer o jogo.

### Dicas

- Usa o scroll para alternar entre a pistola e a metralhadora conforme a situação.
- O som de arma vazia avisa quando precisas de recarregar (recolher munição).
- O flash vermelho indicam quando estás a receber dano.
- Explora o mapa para encontrar pickups escondidos.

---

## Assets

### Scripts (C#)

| Script | Descrição |
|--------|-----------|
| `PlayerMovement.cs` | Movimentação do jogador com CharacterController, gravidade, salto e inércia no ar. |
| `MouseLook.cs` | Controlo da câmara com o rato, incluindo sistema de recoil. |
| `PlayerHealth.cs` | Gestão da saúde do jogador, UI de HP, flash de dano e morte. |
| `Gun.cs` | Lógica de disparo das armas: raycast, dano, muzzle flash, impacto e recoil. |
| `WeaponBob.cs` | Animação procedural da arma (tilt ao saltar/aterrar). |
| `ToolSwitcher.cs` | Troca de armas via scroll do rato. |
| `CameraSwitcher.cs` | Alternância entre câmara em 1ª pessoa e câmara estática. |
| `AmmoUI.cs` / `TargetUI.cs` | UI de munição e contador de kills. |
| `EnemyMovement.cs` | Movimentação dos inimigos com NavMeshAgent e perseguição do jogador. |
| `EnemyDamage.cs` | Dano corpo-a-corpo dos inimigos na proximidade. |
| `Shoot.cs` | Disparo de projéteis pelos inimigos atiradores. |
| `Target.cs` | Saúde dos inimigos, morte com partículas, som e drop de itens. |
| `BulletDamage.cs` | Dano causado pelos projéteis dos inimigos ao jogador. |
| `DeathEffect.cs` | Efeito visual de crescimento e explosão ao morrer. |
| `HealthPickup.cs` / `AmmoPickup.cs` | Recolha de vida e munição com som. |
| `ItemMotion.cs` | Animação de flutuação e rotação dos pickups. |
| `WinLevel.cs` | Passagem de nível e carregamento de cenas. |
| `MainMenu.cs` / `SecondMenu.cs` / `GameOverMenu.cs` | Menus do jogo. |
| `TimedPanel.cs` | Painel de instruções temporárias: exibe-se automaticamente e oculta-se após `displayDuration` segundos. |

### Prefabs principais

- `Player.prefab` — Jogador com câmara, armas e UI.
- `Bullet.prefab` — Projétil dos inimigos.
- `Boss.prefab` — Inimigo Boss.
- `HealthItem.prefab` / `BulletItem01.prefab` — Pickups de vida e munição.
- `DeathEffect.prefab` / `DeathParticles.prefab` — Efeitos de morte.
- `MachineGun.prefab` / `Shotgun.prefab` — Armas do jogador.

### Texturas e Materiais

- Materiais customizados: `Brick.mat`, `Lava.mat`, `Stone.mat`, `Tiles.mat`, `Gold.mat`, `Green.mat`, `Ground.mat`, `GunMetal.mat`, `PlayerMaterial.mat`.
- Texturas diversas na pasta `Assets/Textures/`.
- Skyboxes da coleção **AllSkyFree** (noite, overcast, deep dusk).

### Áudio

| Ficheiro | Origem / Uso |
|----------|--------------|
| `632821__cloud-10__gunshot.wav` | Som de tiro |
| `528708__rolly-sfx__empty-ruger-rifle.flac` | Som de arma vazia |
| `758966__camtheman28__coin-sfx.wav` | Som de recolha de item |
| `dscacdth.wav` / `dspopain.wav` | Sons de morte e dor dos inimigos (originais do DOOM 1993) |

> Nota: os sons `dscacdth.wav` e `dspopain.wav` são assets clássicos do DOOM, utilizados aqui como referência/homenagem ao jogo que inspirou o projeto.

### Cenas

- `OpeningScene.unity` — Menu principal.
- `FirstLevel.unity` — Nível 1.
- `SecondLevel.unity` — Nível 2.
- `ThirdLevel.unity` — Nível 3 (Boss final).
- `LevelComplete.unity` — Ecrã de nível completo.
- `GameOver.unity` — Ecrã de Game Over.
- `WinGame.unity` — Ecrã de vitória final.

### Packages Unity utilizados

- **Universal Render Pipeline (URP)** — Pipeline de renderização.
- **Input System** — Sistema de input moderno para controlos.
- **AI Navigation (NavMesh)** — Navegação dos inimigos.
- **TextMesh Pro** — Texto de UI.
- **ProBuilder** — Modelação de níveis.

---

## Observações

- O jogo utiliza o **Unity Input System** para os controlos, garantindo uma gestão mais robusta do input.
- A navegação dos inimigos depende de **NavMesh baked** em cada cena.
- O recoil das armas é aplicado programaticamente na câmara (`MouseLook.cs`), criando um efeito dinâmico e responsivo.
- A troca de câmara (tecla **C**) pode ser útil para observar o nível ou para debug, mas a jogabilidade principal é em 1ª pessoa.
- Os pickups utilizam o sistema de física apenas para deteção de triggers (não há rigidbody nos itens), e animam-se via script (`ItemMotion.cs`).
- O projeto foi desenvolvido com fins académicos para a disciplina de Tecnologias Multimédia.
