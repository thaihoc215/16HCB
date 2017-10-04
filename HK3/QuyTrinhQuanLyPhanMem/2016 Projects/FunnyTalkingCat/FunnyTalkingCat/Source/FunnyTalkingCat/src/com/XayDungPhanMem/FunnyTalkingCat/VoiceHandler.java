package com.XayDungPhanMem.FunnyTalkingCat;

import com.XayDungPhanMem.FunnyTalkingCat.TomCatState.StateType;

import android.media.AudioFormat;
import android.media.AudioManager;
import android.media.AudioRecord;
import android.media.AudioTrack;
import android.media.MediaRecorder;
import android.os.Environment;


public class VoiceHandler implements Runnable
{
	
	/*
	 * Singleton Design Pattern
	 */
	private static VoiceHandler INSTANCE = null;
	
	public static VoiceHandler getInstance()
	{
		if (null == INSTANCE){
			INSTANCE = new VoiceHandler();
		}
		
		return INSTANCE;
	}
	
	/*
	 * Variables
	 */
	private int freq = 8000;
	private AudioRecord audioRecord = null;
	private Thread recordingThread = null;
	private AudioTrack audioTrack = null;
	short[] buffer;
    short[] audioOutputData = new short[1000000];
    public int nextPos = 0;
	private int maxAmplitude = 8000;
	public boolean listening;
	private boolean isPlaying = false;
	private long startTime = -1;
	private boolean readyForUse = false;
	
	/*
	 * Methods
	 */
	public void init()
	{	
		if(!Environment.MEDIA_MOUNTED.equals(Environment.getExternalStorageState()))
		{
			System.exit(0);
		}

		try {
			this.prepareVoiceRecording();
			this.readyForUse = true;
		} catch (IllegalStateException e) {
			e.printStackTrace();
		}
	}
		
	protected void prepareVoiceRecording() throws IllegalStateException { 

	    android.os.Process.setThreadPriority(android.os.Process.THREAD_PRIORITY_URGENT_AUDIO);
	    final int bufferSize = AudioRecord.getMinBufferSize(freq,
	            AudioFormat.CHANNEL_IN_STEREO,
	            AudioFormat.ENCODING_PCM_16BIT);

	    this.audioRecord = new AudioRecord(MediaRecorder.AudioSource.MIC, freq,
	            AudioFormat.CHANNEL_IN_STEREO,
	            MediaRecorder.AudioEncoder.AMR_WB, 2 * bufferSize);

	    this.audioTrack = new AudioTrack(AudioManager.STREAM_MUSIC, freq,
	            AudioFormat.CHANNEL_OUT_STEREO,
	            MediaRecorder.AudioEncoder.AMR_WB, bufferSize,
	            AudioTrack.MODE_STREAM);
	    this.audioTrack.setPlaybackRate((int)(freq * 1.3));
	    this.audioTrack.setStereoVolume(AudioTrack.getMaxVolume(), AudioTrack.getMaxVolume());
	    this.buffer = new short[bufferSize];

	    this.audioRecord.startRecording();
	    this.audioTrack.play();
	
	    this.recordingThread = new Thread(INSTANCE);	    
	    this.recordingThread.start();
	}
		
	@Override
	public void run() {
        while (true) {
            try {
                audioRecord.read(buffer, 0, buffer.length);
                
                int start = -1;
                for (int i = 0; i < buffer.length; i++)
                {
                	if (Math.abs(buffer[i]) > maxAmplitude && start == -1 && !isPlaying)
                	{  
                		if (TomCat.getInstance().getCurrentState().type == StateType.NORMAL || 
                				TomCat.getInstance().getCurrentState().type == StateType.BLINK || 
                				TomCat.getInstance().getCurrentState().type == StateType.LISTEN)
                		{
                			start = i;
                    		listening = true;
                    		if (TomCat.getInstance().getCurrentState().type != StateType.LISTEN)
                    		{
                    			TomCat.getInstance().getCurrentState().changeTo(StateType.LISTEN); 
                    			if (SoundManager.getInstance().curSound != null)
                    				SoundManager.getInstance().curSound.stop();
                    		}
                		}
                	}	              
                }
                if (start != -1)
                {	
                	startTime = -1;
                	if (nextPos == 0)
	                    for (int i=start; i<buffer.length; i++)
	                    	audioOutputData[nextPos++] = buffer[i];
                	else
                		for (int i=0; i<buffer.length; i++)
                			audioOutputData[nextPos++] = buffer[i];
                }
                else
                {
                	if (nextPos != 0)
                	{                   		
                		for (int i=0; i<buffer.length; i++)
                			audioOutputData[nextPos++] = buffer[i];	                    		
                		if (startTime == -1)
                			startTime = System.currentTimeMillis();
                		else
                		{
                			if ((System.currentTimeMillis() - startTime) * 1.0 / 1000 >= 0.5)
                			{
                				listening = false;
                			}
                		}                    		
                	}
                }
            } catch (Throwable t) {
                t.printStackTrace();
            }
        }
	}

	public void playback()
	{
		if (!this.readyForUse)
		{
			return;
		}
		
		isPlaying = true;
		new Thread(new Runnable(){
		@Override
		public void run() {
			if (null != SoundManager.getInstance().curSound){
				SoundManager.getInstance().curSound.stop();
			}
			
			audioTrack.write(audioOutputData, 0, nextPos);				
			nextPos = 0;
			isPlaying = false;
			if (TomCat.getInstance().getCurrentState().type == StateType.TALK)
				TomCat.getInstance().getCurrentState().changeTo(StateType.NORMAL);
		}				
		}).start();
	}

	public void release()
	{		
		if (null != this.audioOutputData){
			audioOutputData = null;
		}
		
		if (null != this.audioTrack){
			audioTrack.stop();
		}
		
		if (null != this.audioRecord){
			audioRecord.stop();
		}
	}
}