const socket = io('http://localhost:3000')
const messageContainer = document.getElementById('chatArea')
const btn = document.getElementById('sendButton')
const message = document.getElementById('messageBox')

const name = prompt('What is your name?')

addMessage('You joined', true, true)
socket.emit('newUser', name)

socket.on('newMessage', data => {
    addMessage(`${data.name}: ${data.message}`)
})

socket.on('userIn', name => {
    addMessage(`${name} joined`, false, true)
})

socket.on('userOut', name => {
    addMessage(`${name} left`, false, true)
})

btn.addEventListener('click', e => {
    addMessage(`${message.value}`, true)
    socket.emit('messageSent', message.value)
    message.value = ''
});

message.addEventListener("keyup", function(e) {
    if (event.key === 'Enter') {
        btn.click();
    }
});

function addMessage(message, self = false, center = false) {
    const messageElementCont = document.createElement('div')

    messageElementCont.className = "row"

    const messageElement = document.createElement('div')

    if (center) {
        messageElement.className = "col-12 d-flex justify-content-center align-items-center bg-secondary text-white justify-content-center p-3 fs-3"
    } else if (self) {
        messageElementCont.className += " justify-content-end"
        messageElement.className = "col-6 d-flex justify-content-end bg-warning text-white justify-content-end p-3 fs-3 mr-2"
    } else {
        messageElement.className = "col-6 bg-info text-white p-3 fs-3 ml-2"
    }

    messageElement.className += " my-3 rounded-pill"
    messageElement.innerText = message

    messageElementCont.append(messageElement)
    messageContainer.append(messageElementCont)
}