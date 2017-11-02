package com.hcmus.authenticator;

import android.app.ProgressDialog;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import retrofit.Call;
import retrofit.Callback;
import retrofit.GsonConverterFactory;
import retrofit.Response;
import retrofit.Retrofit;
import retrofit.http.GET;
import retrofit.http.Query;

public class NhapMaThuCongActivity extends AppCompatActivity implements Callback<NhapMaThuCongActivity.TaiKhoanDangNhap>{

    Button btnThem;
    String secretKey;
    EditText etTenTaiKhoan, etMaCuaBan;
    ProgressDialog dialogDangDangNhap;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_nhap_ma_thu_cong);
        etTenTaiKhoan=(EditText)findViewById(R.id.etTenTaiKhoan);
        etMaCuaBan=(EditText)findViewById(R.id.etNhapKhoaCuaBan);
        btnThem=(Button)findViewById(R.id.btnThem);

        // Get a support ActionBar corresponding to this toolbar
        ActionBar ab = getSupportActionBar();
        // Enable the Up button
        ab.setDisplayHomeAsUpEnabled(true);

        getSupportActionBar().setBackgroundDrawable(new ColorDrawable(Color.parseColor( "#4285F4")));


        btnThem.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Khởi tạo Retrofit để gán API ENDPOINT (Domain URL) cho Retrofit 2.0
                secretKey=etMaCuaBan.getText().toString();
                Retrofit retrofit = new Retrofit.Builder()
                        .baseUrl("http://2stepauthentication.azurewebsites.net")
                        // Sử dụng GSON cho việc parse và maps JSON data tới Object
                        .addConverterFactory(GsonConverterFactory.create())
                        .build();

                // Khởi tạo các cuộc gọi cho Retrofit 2.0
                DangNhapAPI API = retrofit.create(DangNhapAPI.class);

                Call<TaiKhoanDangNhap> call = API.loadTaiKhoan(secretKey);
                dialogDangDangNhap = new ProgressDialog(NhapMaThuCongActivity.this);
                dialogDangDangNhap.setMessage("Đang đăng nhập...");
                dialogDangDangNhap.show();
                // Cuộc gọi bất đồng bọ (chạy dưới background)
                call.enqueue(NhapMaThuCongActivity.this);
            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        //Chỉ có 1 nút back nên khỏi switch chi hết
        this.onBackPressed();
        return true;
    }

    @Override
    public void onResponse(Response<TaiKhoanDangNhap> response, Retrofit retrofit) {
        dialogDangDangNhap.dismiss();
        if(response.body().getLoginState()){
            if(response.body().getUsername().trim().equals(etTenTaiKhoan.getText().toString().trim())){
                //Trường hợp đăng nhập thành công thì lưu dô share preferences
                SharedPreferences share=getSharedPreferences("DanhSachTaiKhoan", MODE_PRIVATE);
                SharedPreferences.Editor editor=share.edit();
                String value= response.body().getUsername()+"#"+secretKey;
                editor.putString(response.body().getUsername(),value);
                editor.commit();

                Intent intent=new Intent(NhapMaThuCongActivity.this, HoanTatDangNhapActivity.class);
                startActivity(intent);
            }else
            {
                Toast.makeText(this,"Đăng nhập thất bại, mã xác nhân  không đúng cho tài khoản này.",Toast.LENGTH_LONG).show();
            }
        }
        else
            Toast.makeText(this,"Đăng nhập thất bại, tài khoản này chưa bật xác minh 2 bước.", Toast.LENGTH_LONG).show();
    }

    @Override
    public void onFailure(Throwable t) {
        Toast.makeText(this,"Không kết nối được với dịch vụ.",Toast.LENGTH_LONG).show();
    }


    public class TaiKhoanDangNhap{
        private String username;
        private Boolean loginState;

        public String getUsername() {
            return username;
        }

        public void setUsername(String username) {
            this.username = username;
        }

        public Boolean getLoginState() {
            return loginState;
        }

        public void setLoginState(Boolean loginState) {
            this.loginState = loginState;
        }
    }
    public interface DangNhapAPI{
        @GET("/api/android/login/{secretKey}")
        Call<TaiKhoanDangNhap> loadTaiKhoan(@Query("secretKey") String secretKey);
    }
}
