package com.hcmus.authenticator;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.DialogFragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.Toast;

import static android.content.Context.MODE_PRIVATE;

/**
 * Created by MyPC on 24/12/2016.
 */

public class dialogDoiTen extends DialogFragment {
    EditText etTenMoi;
    String tenTaiKhoan="";
    String maTaiKhoan="";
    @NonNull
    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState) {
        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
        // Get the layout inflater
        LayoutInflater inflater = getActivity().getLayoutInflater();
        //Lấy tên và mã tài khoản được truyền từ contextmenu
        tenTaiKhoan=getArguments().getString("TenTaiKhoan");
        maTaiKhoan=getArguments().getString("MaTaiKhoan");

        // Inflate and set the layout for the dialog
        // Pass null as the parent view because its going in the dialog layout
        View dialogView = inflater.inflate(R.layout.dialog_doi_ten, null);
        etTenMoi=(EditText) dialogView.findViewById(R.id.etTenMoi);
        etTenMoi.setText(tenTaiKhoan);

        builder.setView(dialogView)
                // Add action buttons
                .setPositiveButton(R.string.luu, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int id) {
                        if(!etTenMoi.getText().toString().equals("")){
                            SharedPreferences share=getActivity().getSharedPreferences("DanhSachTaiKhoan", MODE_PRIVATE);
                            String secretKey=share.getString(maTaiKhoan,"").toString().split("#")[1];
                            SharedPreferences.Editor editor=share.edit();
                            String value=etTenMoi.getText().toString()+"#"+secretKey;
                            editor.putString(maTaiKhoan,value);
                            editor.commit();
                            //load lại danh sách với tên mới
                            getActivity().finish();
                            startActivity(getActivity().getIntent());
                        }
                    }
                })
                .setNegativeButton(R.string.huy, new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialogDoiTen.this.getDialog().cancel();
                    }
                });
        return builder.create();
    }

}
