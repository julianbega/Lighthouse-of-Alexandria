# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.1] - 2021-09-13
### Added
- Move enemies proto 3.
- Build manager arreglado.
- Towers shoot iluminated enemies.
- Barco de ataque rapido - boceto.
- Torres de arqueros - boceto.
- Faro - boceto.
- Botones para mostrar cuales son los botones para los cheats.
- Islas con primitivas de unity.
- Funcionalidad de niveles.
- Biblioteca de alejandria prototipo funcional.
- Mejorar la tienda.
- Si es de dia los enemigos este iluminados.
- Al terminar un nivel hay un ciclo de construccion y charla con NPCs.
- Hacer 20 Niveles para testeo.
- Hacer textos de las charlas de los npcs (burdamente).
- polishing features / cheats.

## [0.2] - 2021-09-19
### Added
- Enemies Movement.
- Fix bugs de barcos.
- Dialogo con NPC al iniciar el juego antes del primer lvl.
- Funcionalidades de los dialogos.
- Niveles por ScriptableObjects.
- Mejorar cheats.
- Arreglar UI.
- Que los barcos giren segun el camino que siguen.
- Prototipo funcional de upgrade de torres.

## [0.3] - 2021-09-27
### Added
- NPCs - bocetos.
- Menu base.
- Restart.
- Quit.
- Barra de vida de enemigos.
- Solucionado enemigo llega al final del mapa.
- Islas con terrain.
- Los nodos estan invisibles y solo se muestran al pasar el mouse encima.
- Solucionado bug enemigo iluminado.
- Pausa.
- Que la tienda muestre las stats de la torre.
- Hacer que las torres sean funcionalmente distintas.
- Upgrade de torres funcional.
- Marcar cual es el nodo seleccionado mientras estamos upgradeando o comprando.
- Mostrar el rango de las torres al poner el mouse encima.
- Hacer build.

## [0.4] - 2021-10-01
### Added
- UI.
- Botones de opciones.
- Menu - home.
- Settings visual.
- Mostrar en UI el numero de "dia/noche" (nivel).
- Condicion de victoria.
- Fix: se restan las vidas del faro al matar barcos.
- Condicion de derrota.

## [0.5] - 2021-10-12
### Added
- Crear efecto de agua.
- Bloqueos - Prototipo1.
- Efecto de cambio dia noche.
- Frena las interacciones con cosas de UI (tienda, upgrades, cheats, pause) cuando aparece el victory o defeat.
- Mejorar UI.
- Agregar mas piedras.
- Activar los canales a medida que de limpian las piedras.

## [0.6] - 2021-10-19
### Added
- Arrelgar que no se seleccionen los nodos cuando no deben.
- No se pueda hacer otras cosas durante dialogos con NPCs.
- Nueva tienda, alrrededor del nodo.
- Hacer más niveles.
- Entorno de menú.
- Responsive Menu.
- Arreglar que el primer nivel se mantenga de dia.
- aplicar arte en unity.

## [0.7] - 2021-10-25
### Added
- Bloqueo de piedras.
- Punteros personalizados.
- biblioteca alejandria-Prototipo1.
- Arreglar el agua al no haber luz.
- Bug Fix: No se hace de día al matar a todos los enemigos.
- Ordenar el proyecto.
- Agregar rotación suave a los barcos.

## [0.8] - 2021-11-02
### Added
- Integrar Wwise.
- Generalizar NPCs.
- Renombrar Scripts.
- Generalizar los enemigos.
- Agregar pantallas.
- Generalizar la UI.
- Aplicar arte personalizado.

## [0.8.1] - 2021-11-03
### Added
- Arreglar que con none NPC no aparezca la UI de NPC.
- Fix: El juego se detiene luego del nivel 5.
- FixBug: enemigos se spawnean encimados.
- FixBug: No pasa nada cuando terminas todos los lvls.
- Fix luz de noche.
- FixBug: No se puede construir luego de volver del menu de juego al gameplay.
- Hacer que las torres se renderizen en la camara que no es main.

## [0.9.0] - 2021-11-09
### Added
- Fix: Al iniciar el gameplay esta de noche.
- FixBug: Aplicar bloqueos por nivel.
- Sistema de investigacion de upgrades/library system.

## [0.9.1] - 2021-11-11
### Added
- Fix bug Al matar a los barcos apenas spawnean nunca termina la noche.
- Checkear los bloqueos, que estén todos, no se pierdan referencias, desaparezcan cuando es debido y los caminos aparezcan.
- Fix bug: queda vivo un barco y pasa al dia.
- Fix bug: no se pueda poner torres donde ya hay torres.
- Fix bug: única posición de la tienda luego de perder.
- Fix bug: El cañon se detiene si el enemigo muere despues de la colision.
- fix bug: al terminar de investigar no aparecen las torres desbloqueadas.
- Wwise: evento ui_button_hover.

## [0.10.0] - 2021-11-17
### Added
- Fix: Mejorar transparencia de los sprites de los botones.
- Cambiar upgrade de aumento de rango por aumento de velocidad de ataque.
- FixBug, no hay enemigo y no termina el nivel.
- Menú funcional v2.
- Upgrade torres.
- Conectar Jira al Git.

## [0.11.0] - 2021-11-23
### Added
- Fix index error.
- Tag line.
- Solucionar prefabs de enemigos.
- Cambiar escala de prefabs.
- Chequeo de enemigos.
- Arreglar cheats y sacar los que no van.
- Tower prefabs.
- Cambiar todo lo de UI y menues y etc al mismo idioma.
- Hacer un CHANGELOG.md.
- Checkear coupling.
- Descripción completa.
- VolumeManager (singleton).
- Checkeo UI escalable.
- Implementacion sonidos y musica.
- Configurar el About del repo.
- Cambiar de fullscreen a modo ventana en settings.
- Checkeo de standards de C#.
- Nuevo: Cada barco da una cantidad de dinero distinto al morir.
- Hacer un Read.me.
- SplashScreen.
- Nuevo: Mas niveles.
- Estructura: Nuevos nombres de carpetas y de scripts.
- Credits completar nombres.
- Nuevo: Balanceo del juego.

## [0.12.0] - 2021-11-29
### Added

- boton de play y pausa para gameplay.
- iconos investigaciones.
- textura barcos.
- textura faro.
- textura biblioteca.
- textura torre arquero.
- logo.
- icono.
- pagina fondo para itch.io.
- textura muro de rocas.
- textura muros.
- banner para itch.io.
- Al perder o ganar aparece un cartel de victory o defeat.
- FixBug: Interaccion con tienda rompe la pausa.
- Fix bug: Shop y upgrade se muestran a la misma vez.
- Implementacion de audio v2.
- Codigo de UIShop agregado.
- Fonts agregadas.

## [0.13.0] - 2022-02-1
### Added

- Pausa en GameManager.
- Aplicadas texturas de todos los objetos.
- Mejorado GameManager.
- Nueva tipografia paa UI.
- Nuevos sprites de victoria/derrota.

## [0.13.1] - 2022-02-6
### Added

- Fix bug: barco no muere al final.
- Fix bug: barco rapido aparece iluminado.
- Fix bug: generalizar metodo shoot de turret.
- Fix Animator controller en el Menu.
- Fix canvas scaler en settings.
- Fix canvas scaler en credits.

## [0.14.0] - 2022-03-5
### Added

- Nueva UI.
- Nuevas pantallas de victory/defeat.
- Mejorado metodo HitTarget.
- Nuevo panel de settings.
- Mejorado script de UIUpgradeSystem.
- Mejorado script de UIInvestigation.
- Solucionado algunos errores en sonidos.
- LevelManager singleton.
- Fix: no se puede comprar durante waves.

## [0.15.0] - 2022-03-6
### Added

- Consistencia del idioma en todo el juego.
- Al perder no se puede interactuar con la UI.
- Removidas imagenes de NPCs.
- Actualizadas imagenes de la libreria.

## [1.0.0] - 2022-03-6
### Added

- Fix: bullet no se destruye al impactar con enemigo.
- pueblo - prototipo1
- presskit completo
- Post mortem de desarrollo.