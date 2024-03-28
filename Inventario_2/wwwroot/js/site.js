document.addEventListener('DOMContentLoaded', function () {
    // Obtener elementos del DOM
    const colorfulBox = document.getElementById('colorfulBox');
    const changeColorBtn = document.getElementById('changeColorBtn');
    const resetColorBtn = document.getElementById('resetColorBtn');
    const changeTextColorBtn = document.getElementById('changeTextColorBtn'); // Nuevo botón

    // Evento de clic para cambiar el color de fondo
    changeColorBtn.addEventListener('click', function () {
        const randomColor = getRandomColor();
        setColor(colorfulBox, randomColor);
    });

    // Evento de clic para restablecer el color de fondo
    resetColorBtn.addEventListener('click', function () {
        setColor(colorfulBox, '#ffffff'); // Color blanco
    });

    // Evento de clic para cambiar el color de texto
    changeTextColorBtn.addEventListener('click', function () {
        const randomColor = getRandomColor();
        setTextColor(colorfulBox, randomColor);
    });

    // Función para establecer el color de fondo de un elemento
    function setColor(element, color) {
        element.style.backgroundColor = color;
    }

    // Función para establecer el color de texto de un elemento
    function setTextColor(element, color) {
        element.style.color = color;
    }

    // Función para generar un color aleatorio en formato hexadecimal
    function getRandomColor() {
        const letters = '0123456789ABCDEF';
        let color = '#';
        for (let i = 0; i < 6; i++) {
            color += letters[Math.floor(Math.random() * 16)];
        }
        return color;
    }

    // Otras funciones o lógica aquí
});
