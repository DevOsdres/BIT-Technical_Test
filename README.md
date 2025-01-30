# BIT-Technical_Test
  

# Old Heaven  

### 📌 Descripción  
_Old Heaven_ es un juego desarrollado en **Unity** donde el jugador asume el rol de un comerciante en un punto de control fronterizo. La mecánica principal consiste en seleccionar los productos correctos para completar pedidos dentro de un tiempo límite, evitando artículos ilegales y posibles trampas policiales.  

Este proyecto fue desarrollado como parte de una **prueba técnica para BIT**, destacando habilidades en programación, generación de pedidos aleatorios, gestión de inventario e interacción con UI en Unity.  

---

### 🎮 Mecánicas de Juego  

- **Recepción de órdenes**: Se generan pedidos aleatorios con productos legales e ilegales.  
- **Selección de productos**: El jugador elige qué productos entregar desde el inventario.  
- **Tiempo límite**: Cada orden debe completarse antes de que el tiempo se agote.  
- **Trampas policiales**: Algunas órdenes pueden ser señuelos de las autoridades.  

---

### ⌨️ Controles  

| Acción           | Tecla/Interacción |
|-----------------|------------------|
| Seleccionar producto | Click izquierdo en el ítem |
| Entregar pedido | Botón "Deliver Order" |
| Navegar en la UI | Mouse |

---

### ⚠️ Condiciones de Derrota  

- **Entregar una orden con productos incorrectos**: No hay penalización, pero se considera un error.  
- **No entregar la orden a tiempo**: La orden falla y se genera una nueva.  
- **Caer en una trampa policial**: Si entregas productos ilegales en una orden de las autoridades, pierdes la partida.  

---

### 🛠️ Tecnologías Usadas  

- **Unity** (versión utilizada en el desarrollo)  
- **C#** (lógica del juego)  
- **TextMeshPro** (UI y textos en pantalla)  
