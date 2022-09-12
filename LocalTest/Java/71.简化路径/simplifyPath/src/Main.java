import java.util.ArrayDeque;
import java.util.Deque;

public class Main {
    public static void main(String[] args) {
        Solution solution = new Solution();
        String path = "/a/../../b/../c//.//";
        String res = solution.simplifyPath(path);
        System.out.println(res);
    }
}

class Solution {
    public String simplifyPath(String path) {
        String[] strs = path.split("/");
        Deque<String> resStack = new ArrayDeque<>();
        resStack.push("/");
        for (int i = 0; i < strs.length; i++) {
            if (strs[i].isEmpty() || strs[i].equals(".") || (resStack.size() == 1 && strs[i].equals(".."))) {
                continue;
            }
            if (strs[i].equals("..") && resStack.size() > 1) {
                resStack.pop();
            } else {
                if (i == strs.length - 1) {
                    resStack.push(strs[i]);
                } else {
                    resStack.push((strs[i] + "/"));
                }
            }
        }
        while (resStack.size() > 1 && resStack.peek().equals("/")) {
            resStack.pop();
        }
        String res = "";
        while (resStack.size() > 0) {
            res = resStack.pop() + res;
        }
        while (res.charAt(res.length() - 1) == '/' && res.length() > 1) {
            res = res.substring(0, res.length() - 1);
        }
        return res;
    }
}