const host = 'codenjoy.astanajug.net:8080/codenjoy-contest';
const userName = 'you_registered_user';
const code = 'password_hash_code';

const server = 'ws://' + host +  '/ws';
const WebSocket = require('ws');
const ws = new WebSocket(server + '?user=' + userName + '&code=' + code);

function commandForSnake(board) {
    return 'LEFT';
}

ws.on('open', function() {
    console.log('Opened');
});

ws.on('close', function() {
    console.log('Closed');
});

ws.on('message', function(message) {
    const board = message.substring("board=".length, message.length);
    printBoard(board);
    let command = commandForSnake();
    ws.send(command);
});

console.log('Web socket client running at ' + server);

function printBoard(message) {
    const fieldLength = Math.sqrt(message.length)|0;

    for (let i = 0; i < fieldLength; i++) {
        console.log(message.substring(i * fieldLength, fieldLength * (i + 1)));
    }
}

const stone = '☻';
const apple = '☺';
const head = ['▲', '◄', '►', '▼'];
const body = ['║', '═', '╗', '╝', '╔', '╚'];
const tail = ['╙', '╘', '╓', '╕'];
const wall = '☼';