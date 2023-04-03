const io = require('socket.io')(3000)
const users = {}

io.on('connection', (socket) => {

    socket.on('newUser', name => {
        users[socket.id] = name
        socket["broadcast"].emit('userIn', name)
    })

    socket.on('messageSent', message => {
        socket["broadcast"].emit('newMessage', {message: message, name: users[socket.id]})
    })

    socket.on('disconnect', () => {
        socket["broadcast"].emit('userOut', users[socket.id])
        delete users[socket.id]
    })
})