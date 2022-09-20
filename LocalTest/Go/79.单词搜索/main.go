package main

import "fmt"

func main() {
	board := [][]byte{{'A', 'B', 'C', 'E'}, {'S', 'F', 'C', 'S'}, {'A', 'D', 'E', 'E'}}
	word := "ABCB"
	res := exist(board, word)
	fmt.Println(res)
}

func exist(board [][]byte, word string) bool {
	m := len(board)
	n := len(board[0])
	wordLen := len(word)
	if m*n < wordLen {
		return false
	}
	used := make([][]bool, m)
	for i := range used {
		used[i] = make([]bool, n)
	}
	index := 0
	row := 0
	col := 0
	var dfs func() bool
	dfs = func() bool {
		if index == wordLen {
			return true
		}
		if row-1 >= 0 && !used[row-1][col] && board[row-1][col] == word[index] {
			row--
			index++
			used[row][col] = true
			if dfs() {
				return true
			}
			used[row][col] = false
			index--
			row++
		}
		if row+1 < m && !used[row+1][col] && board[row+1][col] == word[index] {
			row++
			index++
			used[row][col] = true
			if dfs() {
				return true
			}
			used[row][col] = false
			index--
			row--
		}
		if col-1 >= 0 && !used[row][col-1] && board[row][col-1] == word[index] {
			col--
			index++
			used[row][col] = true
			if dfs() {
				return true
			}
			used[row][col] = false
			index--
			col++
		}
		if col+1 < n && !used[row][col+1] && board[row][col+1] == word[index] {
			col++
			index++
			used[row][col] = true
			if dfs() {
				return true
			}
			used[row][col] = false
			index--
			col--
		}
		return false
	}
	for i := 0; i < m; i++ {
		for j := 0; j < n; j++ {
			if board[i][j] == word[0] {
				used[i][j] = true
				index++
				row, col = i, j
				if dfs() {
					return true
				}
				index--
				used[i][j] = false
			}
		}
	}
	return false
}
