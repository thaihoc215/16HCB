package com.G6.TexturePacker;
/*Su dung:
 *Chuot phai vao MyTTPacker
 *Run as java application de pack hinh anh tu MyData sang MyDataPacker
 * */

import com.badlogic.gdx.tools.imagepacker.TexturePacker2;
import com.badlogic.gdx.tools.imagepacker.TexturePacker2.Settings;

/*
 * TexturePacker giúp chuyển tất cả các ảnh đơn thành một ảnh tổng hợp chứa tất cả các ảnh đó
 */
public class MyTTPacker {
	
	public static void main(String[] args) {
		Settings tt = new Settings();
		tt.maxWidth = 1024;
		tt.minHeight = 1024;
		
		/*
		 * Mỗi thư mục con là sẽ được chuyển thành 1 hình
		 * 
		 * Nếu chúng ta đặt tên theo định dạng: <tên>_<số thứ tự>.<đuôi> thì sau khi chuyển, trong file
		 * info (thuộc tính thứ 4) các ảnh đó sẽ được
		 * lưu với tên chung là <đường dẫn>/<tên>.<đuôi> và khác nhau số index. nó sẽ giúp chúng ta lấy tất cả
		 * các file qua tên chung này
		 * 
		 * thuộc tính thứ 2: có nghĩa là thư mục gốc cần chuyển (input)
		 * 				  3: thư mục output
		 * 				  4: file chưa tất cả nội dung của tất cả các hình đã chuyển
		 */
		TexturePacker2.process(tt, "MyData/", "MyDataPacker/", "info.txt");
	}
}
