package com.hcmus.authenticator;

import android.graphics.Color;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.view.ViewPager;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;

import com.rd.PageIndicatorView;
import com.rd.animation.AnimationType;

public class HowItWorksActivity extends FragmentActivity implements View.OnClickListener {


    Button btnSkip;
    ImageButton imgbtnNext;
    Button btnDone;
    ViewPager viewPager;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_how_it_works);

        viewPager = (ViewPager) findViewById(R.id.viewPager);
        viewPager.setAdapter(new MyPagerAdapter(getSupportFragmentManager()));

        PageIndicatorView pageIndicatorView = (PageIndicatorView) findViewById(R.id.pageIndicatorView);
        pageIndicatorView.setViewPager(viewPager);

        pageIndicatorView.setCount(3);
        pageIndicatorView.setSelectedColor(Color.WHITE);

        pageIndicatorView.setAnimationType(AnimationType.THIN_WORM);

        btnSkip = (Button) findViewById(R.id.howitworks_button_skip);

        btnSkip.setOnClickListener(this);
        imgbtnNext = (ImageButton) findViewById(R.id.howitworks_button_next);
        imgbtnNext.setOnClickListener(this);
        btnDone = (Button) findViewById(R.id.howitworks_button_done);
        btnDone.setOnClickListener(this);

        viewPager.setOnPageChangeListener(new ViewPager.OnPageChangeListener() {
            @Override
            public void onPageScrolled(int position, float positionOffset, int positionOffsetPixels) {

            }

            @Override
            public void onPageSelected(int position) {
                if (position == 2) {
                    imgbtnNext.setVisibility(View.GONE);
                    btnDone.setVisibility(View.VISIBLE);
                } else {
                    imgbtnNext.setVisibility(View.VISIBLE);
                    btnDone.setVisibility(View.GONE);
                }
            }

            @Override
            public void onPageScrollStateChanged(int state) {

            }
        });
    }

    @Override
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.howitworks_button_skip:
                onBackPressed();
                break;
            case R.id.howitworks_button_done:
                onBackPressed();
                break;
            case R.id.howitworks_button_next:
                viewPager.setCurrentItem(viewPager.getCurrentItem() + 1, true);
                break;

        }
    }


    private class MyPagerAdapter extends FragmentPagerAdapter {


        public MyPagerAdapter(FragmentManager fm) {
            super(fm);
        }

        @Override
        public Fragment getItem(int position) {
            switch (position) {

                case 0:
                    return HowItWorkFragment.newInstance(R.layout.fragment_how_it_work_1);
                case 1:
                    return HowItWorkFragment.newInstance(R.layout.fragment_how_it_work_2);
                case 2:
                    return HowItWorkFragment.newInstance(R.layout.fragment_how_it_work_3);
                default:
                    return HowItWorkFragment.newInstance(R.layout.fragment_how_it_work_1);
            }
        }

        @Override
        public int getCount() {
            return 3;
        }
    }
}
