import java.util.*;

public class Main {
    public static void main(String[] args) {
        System.out.println("Hello world!");
    }
}

class Solution {
    public List<List<String>> solveNQueens(int n) {
        Deque<Integer> path = new ArrayDeque<>();
        Deque<boolean[][]> flagStack = new ArrayDeque<>();
        List<List<String>> res = new ArrayList<>();
        getRes(path, flagStack, res, n);
        return res;
    }

    private void getRes(Deque<Integer> path, Deque<boolean[][]> flagStack, List<List<String>> res, int n) {
        if (path.size() == n) {
            List<Integer> tempRes = new ArrayList<>(path);
            Collections.reverse(tempRes);
            List<String> tempStrRes = new ArrayList<>();
            for (int i = 0; i < n; i++) {
                String str = "";
                for (int j = 0; j < n; j++) {
                    if (tempRes.get(i) == j) {
                        str += "Q";
                    } else {
                        str += ".";
                    }
                }
                tempStrRes.add(str);
            }
            res.add(tempStrRes);
            return;
        }
        boolean[][] oldFlags = new boolean[n][n];
        if (!flagStack.isEmpty()) {
            oldFlags = flagStack.peek();
        }
        for (int i = 0; i < n; i++) {
            if (oldFlags[path.size()][i]) {
                continue;
            }
            path.push(i);
            boolean[][] newFlags = getFlagsFromPath(path, n);
            flagStack.push(newFlags);
            getRes(path, flagStack, res, n);
            path.pop();
            flagStack.pop();
        }
    }

    private boolean[][] getFlagsFromPath(Deque<Integer> path, int n) {
        boolean[][] flags = new boolean[n][n];
        List<Integer> tempRes = new ArrayList<>(path);
        Collections.reverse(tempRes);
        for (int i = 0; i < tempRes.size(); i++) {
            for (int row = 0; row < n; row++) {
                for (int col = 0; col < n; col++) {
                    if (row == i || col == tempRes.get(i) || row - i == col - tempRes.get(i) || row - i == tempRes.get(i) - col) {
                        flags[row][col] = true;
                    }
                }
            }
        }
        return flags;
    }
}