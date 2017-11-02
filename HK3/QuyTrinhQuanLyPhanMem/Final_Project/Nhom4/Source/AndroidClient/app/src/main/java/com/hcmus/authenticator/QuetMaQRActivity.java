package com.hcmus.authenticator;

import android.content.Intent;
import android.content.SharedPreferences;
import android.net.ConnectivityManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Toast;

import com.google.zxing.Result;

import me.dm7.barcodescanner.zxing.ZXingScannerView;
import retrofit.Call;
import retrofit.Callback;
import retrofit.GsonConverterFactory;
import retrofit.Response;
import retrofit.Retrofit;
import retrofit.http.GET;
import retrofit.http.Query;

public class QuetMaQRActivity extends AppCompatActivity implements ZXingScannerView.ResultHandler, Callback<QuetMaQRActivity.TaiKhoanDangNhap> {

    private ZXingScannerView myScan;
    String secretKey;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_quet_ma_qr);

        ConnectivityManager connectivityManager=(ConnectivityManager)getSystemService(CONNECTIVITY_SERVICE);
        if(!connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).isConnected() && !connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).isConnected()){
            Toast.makeText(getBaseContext(),"Tính năng này cần phải có kết nối Internet.",Toast.LENGTH_LONG).show();
            return;
        }
        myScan=new ZXingScannerView(QuetMaQRActivity.this);
        setContentView(myScan);
        myScan.setResultHandler(QuetMaQRActivity.this);
        myScan.startCamera();
    }
    @Override
    protected void onPause() {
        super.onPause();
        //Phải try/catch để tránh tình trạng myScan chưa được tạo nên không thể stop
        try{
            myScan.stopCamera();
        }catch (Exception ex){}
    }
    @Override
    public void handleResult(Result result) {
        //myScan.resumeCameraPreview(this);
        // Khởi tạo Retrofit để gán API ENDPOINT (Domain URL) cho Retrofit 2.0
        secretKey=result.getText();
        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl("http://2stepauthentication.azurewebsites.net")
                // Sử dụng GSON cho việc parse và maps JSON data tới Object
                .addConverterFactory(GsonConverterFactory.create())
                .build();

        // Khởi tạo các cuộc gọi cho Retrofit 2.0
        DangNhapAPI API = retrofit.create(DangNhapAPI.class);

        Call<TaiKhoanDangNhap> call = API.loadTaiKhoan(secretKey);
        // Cuộc gọi bất đồng bọ (chạy dưới background)
        call.enqueue(QuetMaQRActivity.this);
    }

    @Override
    public void onResponse(Response<TaiKhoanDangNhap> response, Retrofit retrofit) {
        if(response.body().getLoginState()){
            //Trường hợp đăng nhập thành công thì lưu dô share preferences
            SharedPreferences share=getSharedPreferences("DanhSachTaiKhoan", MODE_PRIVATE);
            SharedPreferences.Editor editor=share.edit();
            String value= response.body().getUsername()+"#"+secretKey;
            editor.putString(response.body().getUsername(),value);
            editor.commit();


            Intent intent=new Intent(QuetMaQRActivity.this, HoanTatDangNhapActivity.class);
            startActivity(intent);
        }
        else{
            Toast.makeText(QuetMaQRActivity.this,"Đăng nhập thất bại",Toast.LENGTH_LONG).show();
            //Load lại activity tại vì trình quét QR không tự thoát ra
            finish();
            startActivity(getIntent());
        }
    }

    @Override
    public void onFailure(Throwable t) {
        Toast.makeText(QuetMaQRActivity.this,"Có lỗi xảy ra",Toast.LENGTH_LONG).show();
    }


    //2 class này phục vụ cho retrofit
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
