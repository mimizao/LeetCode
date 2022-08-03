/*
 * @lc app=leetcode.cn id=36 lang=golang
 *
 * [36] 有效的数独
 */
package main

// @lc code=start
func isValidSudoku(board [][]byte) bool {
	bytesCol := make([]byte, 9)
	bytesRow := make([]byte, 9)
	for i := 0; i < 9; i++ {
		for j := 0; j < 9; j++ {
			bytesCol[j] = board[i][j]
			bytesRow[j] = board[j][i]
		}
		if !isValidBytes(bytesCol) || !isValidBytes(bytesRow) {
			return false
		}
	}
	bytesSudoku0 := []byte{}
	bytesSudoku1 := []byte{}
	bytesSudoku2 := []byte{}
	for i := 0; i < 9; i++ {
		for j := 0; j < 9; j++ {
			if j/3 == 0 {
				bytesSudoku0 = append(bytesSudoku0, board[i][j])
			} else if j/3 == 1 {
				bytesSudoku1 = append(bytesSudoku1, board[i][j])
			} else {
				bytesSudoku2 = append(bytesSudoku2, board[i][j])
			}
		}
		if i%3 == 2 {
			if !isValidBytes(bytesSudoku0) || !isValidBytes(bytesSudoku1) || !isValidBytes(bytesSudoku2) {
				return false
			}
			bytesSudoku0 = []byte{}
			bytesSudoku1 = []byte{}
			bytesSudoku2 = []byte{}
		}
	}
	return true
}

func isValidBytes(bytes []byte) bool {
	byteCount := make(map[byte]int)
	for i := range bytes {
		if bytes[i] != '.' {
			if _, ok := byteCount[bytes[i]]; ok {
				return false
			} else {
				byteCount[bytes[i]] = 1
			}
		}
	}
	return true
}

// @lc code=end
