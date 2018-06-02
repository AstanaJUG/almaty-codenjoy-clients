package com.codenjoy.dojo.snake.client;

import com.codenjoy.dojo.snake.model.Command;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.WebSocket;
import okhttp3.WebSocketListener;

/**
 * User: your name
 */
public class SnakeClient extends WebSocketListener {

    // this is your email
    private static final String USER_NAME = "your_user_name";
    // you can get this code after registration on the server with your email
    private static final String CODE = "your_user_code";

    private static final String CONNECTION_URL = "ws://codenjoy.astanajug.net:8080/codenjoy-contest/ws?user=%s&code=%s";

    public static void main(String[] args) {
        new SnakeClient().execute();
    }

    private void execute() {
        OkHttpClient client = new OkHttpClient.Builder().build();

        Request request = new Request.Builder().url(String.format(CONNECTION_URL, USER_NAME, CODE)).build();

        client.newWebSocket(request, this);

        client.dispatcher().executorService().shutdown();
    }

    @Override
    public void onMessage(WebSocket webSocket, String text) {

        String board = text.substring("board=".length());
        System.out.println(board);

        webSocket.send(calculateCommandForSnake(board));
    }

    private String calculateCommandForSnake(String board) {
        return Command.UP.name();
    }
}
