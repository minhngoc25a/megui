// modified by dimzon, renamed to AvisynthWrapper for futher independent development
// avisynth redirecter dll modified by Inc.
// Original by MobileHackerz http://www.nurs.or.jp/~calcium/

// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <io.h>
#include <fcntl.h>
#include <windows.h>

// include the necessary avisynth.h files
#define AVISYNTH_INTERFACE_BUILD_VERSION 3

#if AVISYNTH_INTERFACE_BUILD_VERSION > 4
// interface 6 does produce a black video frame when using ffms
#include "avs_core_6_mt\avisynth.h"
#elif AVISYNTH_INTERFACE_BUILD_VERSION == 3
// seems to work
#include "avs_core_3\internal.h"
#include "avs_core_3\avisynth.h"
#else
// interface 2 does not work with x64
// but this is the orginal avswrapper avisynth.h
#include "avs_core_2\internal.h"
#include "avs_core_2\avisynth.h"
#endif

typedef __int64 int64_t;
#include "avisynthdll.h"

#define MAX_CLIPS  1024
#define ERRMSG_LEN 1024

#if AVISYNTH_INTERFACE_BUILD_VERSION > 4
const AVS_Linkage *AVS_linkage = 0; // AviSynth 2.6 only
#endif

typedef struct tagSafeStruct
{
	char err[ERRMSG_LEN];
	IScriptEnvironment* env;
	AVSValue* res;
	PClip clp;
	HMODULE dll;
} SafeStruct;

extern "C" {
	__declspec(dllexport) int __stdcall dimzon_avs_init(SafeStruct** ppstr, char *func, char *arg, AVSDLLVideoInfo *vi, int* originalPixelType, int* originalSampleType, char *cs);
	__declspec(dllexport) int __stdcall dimzon_avs_init_2(SafeStruct** ppstr, char *func, char *arg, AVSDLLVideoInfo *vi, int* originalPixelType, int* originalSampleType, char *cs);
	__declspec(dllexport) int __stdcall dimzon_avs_init_3(SafeStruct** ppstr, char *func, char *arg, AVSDLLVideoInfo *vi, int* originalPixelType, int* originalSampleType, char *cs);
	__declspec(dllexport) int __stdcall dimzon_avs_destroy(SafeStruct** ppstr);
	__declspec(dllexport) int __stdcall dimzon_avs_getlasterror(SafeStruct* pstr, char *str, int len);
	__declspec(dllexport) int __stdcall dimzon_avs_getvframe(SafeStruct* pstr, void *buf, int stride, int frm);
	__declspec(dllexport) int __stdcall dimzon_avs_getaframe(SafeStruct* pstr, void *buf, __int64 start, __int64 count);
	__declspec(dllexport) int __stdcall dimzon_avs_getintvariable(SafeStruct* pstr, const char* name, int* result);
	__declspec(dllexport) int __stdcall dimzon_avs_getinterfaceversion(int* result);
}


/*new implementation*/

int __stdcall dimzon_avs_getintvariable(SafeStruct* pstr, const char* name, int* result)
{
	try
	{
		pstr->err[0] = 0;
		try
		{
			AVSValue var = pstr->env->GetVar(name);
			if (var.Defined())
			{
				if (!var.IsInt())
				{
					strncpy_s(pstr->err, ERRMSG_LEN, "Variable is not Integer", _TRUNCATE);
					return -2;
				}
				*result = var.AsInt();
				return 0;
			}
			else
			{
				return 999; // Signal "Not defined"
			}
		}
		catch (AvisynthError err)
		{
			strncpy_s(pstr->err, ERRMSG_LEN, err.msg, _TRUNCATE);
			return -1;
		}
	}
	catch (IScriptEnvironment::NotFound)
	{
		return 666; // Signal "Not Found"
	}
	catch (...)
	{
		strncpy_s(pstr->err, ERRMSG_LEN, "Unhandled error: dimzon_avs_getintvariable", _TRUNCATE);
		return -1;
	}
}

int __stdcall dimzon_avs_getinterfaceversion(int* result)
{
	try
	{
		*result = AVISYNTH_INTERFACE_VERSION;
		return 0;
	}
	catch (...)
	{
		return -1;
	}
}

int __stdcall dimzon_avs_functionexists(SafeStruct* pstr, const char* func, bool* result)
{
	try
	{
		pstr->err[0] = 0;
		try
		{
			AVSValue var = pstr->env->FunctionExists(func);
			if (var.Defined())
			{
				if (!var.IsBool())
				{
					strncpy_s(pstr->err, ERRMSG_LEN, "Variable is not Boolean", _TRUNCATE);
					return -2;
				}
				*result = var.AsBool();
				return 0;
			}
			else
			{
				return 999; // Signal "Not defined"
			}
		}
		catch (AvisynthError err)
		{
			strncpy_s(pstr->err, ERRMSG_LEN, err.msg, _TRUNCATE);
			return -1;
		}
	}
	catch (IScriptEnvironment::NotFound)
	{
		return 666; // Signal "Not Found"
	}
	catch (...)
	{
		strncpy_s(pstr->err, ERRMSG_LEN, "Unhandled error: dimzon_avs_getintvariable", _TRUNCATE);
		return -1;
	}
}

int __stdcall dimzon_avs_getaframe(SafeStruct* pstr, void *buf, __int64 start, __int64 count)
{
	try
	{
		pstr->clp->GetAudio(buf, start, count, pstr->env);
		pstr->err[0] = 0;
		return 0;
	}
	catch (AvisynthError err)
	{
		strncpy_s(pstr->err, ERRMSG_LEN, err.msg, _TRUNCATE);
		return -1;
	}
	catch (...)
	{
		strncpy_s(pstr->err, ERRMSG_LEN, "Unhandled error: dimzon_avs_getaframe", _TRUNCATE);
		return -1;
	}
}

int __stdcall dimzon_avs_getvframe(SafeStruct* pstr, void *buf, int stride, int frm)
{
	try
	{
		PVideoFrame f = pstr->clp->GetFrame(frm, pstr->env);
		if (buf && stride)
		{
			pstr->env->BitBlt((BYTE*)buf, stride, f->GetReadPtr(), f->GetPitch(), f->GetRowSize(), f->GetHeight());
		}
		pstr->err[0] = 0;
		return 0;
	}
	catch (AvisynthError err)
	{
		strncpy_s(pstr->err, ERRMSG_LEN, err.msg, _TRUNCATE);
		return -1;
	}
	catch (...)
	{
		strncpy_s(pstr->err, ERRMSG_LEN, "Unhandled error: dimzon_avs_getvframe", _TRUNCATE);
		return -1;
	}
}

int __stdcall dimzon_avs_getstrfunction(SafeStruct* pstr, char *func, char *str, int len)
{
	try
	{
		AVSValue arg;
		strncpy_s(str, len, pstr->env->Invoke(func, AVSValue(&arg, 0)).AsString(), len - 1);
		return (int)strlen(str);
	}
	catch (...)
	{
		strncpy_s(str, ERRMSG_LEN, "Unhandled error: dimzon_avs_getstrfunction", _TRUNCATE);
		return (int)strlen(str);
	}
}

int __stdcall dimzon_avs_getlasterror(SafeStruct* pstr, char *str, int len)
{
	try
	{
		strncpy_s(str, len, pstr->err, len - 1);
		return (int)strlen(str);
	}
	catch (...)
	{
		strncpy_s(str, ERRMSG_LEN, "Unhandled error: dimzon_avs_getlasterror", _TRUNCATE);
		return (int)strlen(str);
	}
}

int __stdcall dimzon_avs_destroy(SafeStruct** ppstr)
{
	try
	{
		if (!ppstr)
		{
			return 1;
		}

		SafeStruct* pstr = *ppstr;
		if (!pstr)
		{
			return 1;
		}

		if (pstr->clp)
		{
			pstr->clp = NULL;
		}

		if (pstr->res)
		{
			delete pstr->res;
			pstr->res = NULL;
		}

		if (pstr->env)
		{
#if AVISYNTH_INTERFACE_BUILD_VERSION > 4
			pstr->env->DeleteScriptEnvironment(); // AviSynth 2.6
#else
			delete pstr->env; // AviSynth 2.5
#endif
			pstr->env = NULL;
		}

		if (pstr->dll)
		{
			FreeLibrary(pstr->dll);
		}

#if AVISYNTH_INTERFACE_BUILD_VERSION > 4
		AVS_linkage = 0;  // AviSynth 2.6 only
#endif

		free(pstr);
		*ppstr = NULL;
		return 0;
	}
	catch (...)
	{
		return -1;
	}
}

int __stdcall dimzon_avs_init(SafeStruct** ppstr, char *func, char *arg, AVSDLLVideoInfo *vi, int* originalPixelType, int* originalSampleType, char *cs)
{
	SafeStruct* pstr = ((SafeStruct*)malloc(sizeof(SafeStruct)));
	*ppstr = pstr;
	memset(pstr, 0, sizeof(SafeStruct));

	pstr->dll = LoadLibrary("avisynth.dll");
	if (!pstr->dll)
	{
		strncpy_s(pstr->err, ERRMSG_LEN, "Avisynth installation cannot be found", _TRUNCATE);
		return 1;
	}

	IScriptEnvironment* (*CreateScriptEnvironment)(int version) = (IScriptEnvironment*(*)(int)) GetProcAddress(pstr->dll, "CreateScriptEnvironment");
	if (!CreateScriptEnvironment)
	{
		strncpy_s(pstr->err, ERRMSG_LEN, "Cannot load CreateScriptEnvironment", _TRUNCATE);
		return 2;
	}

	pstr->env = CreateScriptEnvironment(AVISYNTH_INTERFACE_VERSION);

	if (pstr->env == NULL)
	{
#if AVISYNTH_INTERFACE_BUILD_VERSION > 4
		strncpy_s(pstr->err, ERRMSG_LEN, "Avisynth 2.6 required", _TRUNCATE);
#else
		strncpy_s(pstr->err, ERRMSG_LEN, "Avisynth 2.5 required", _TRUNCATE);
#endif
		return 3;
	}

#if AVISYNTH_INTERFACE_BUILD_VERSION > 4
	AVS_linkage = pstr->env->GetAVSLinkage(); // AviSynth 2.6 only
#endif

	try
	{
		AVSValue arg(arg);
		AVSValue res = pstr->env->Invoke(func, AVSValue(&arg, 1));
		if (!res.IsClip()) {
			strncpy_s(pstr->err, ERRMSG_LEN, "The script's return was not a video clip.", _TRUNCATE);
			return 4;
		}
		pstr->clp = res.AsClip();
		VideoInfo inf = pstr->clp->GetVideoInfo();
		VideoInfo infh = pstr->clp->GetVideoInfo();

		if (inf.HasVideo())
		{
			*originalPixelType = inf.pixel_type;

			if (strcmp("RGB24", cs) == 0 && (!inf.IsRGB24()))
			{
				res = pstr->env->Invoke("ConvertToRGB24", AVSValue(&res, 1));
				pstr->clp = res.AsClip();
				infh = pstr->clp->GetVideoInfo();

				if (!infh.IsRGB24())
				{
					strncpy_s(pstr->err, ERRMSG_LEN, "Cannot convert video to RGB24", _TRUNCATE);
					return	5;
				}
			}

			if (strcmp("RGB32", cs) == 0 && (!inf.IsRGB32()))
			{
				res = pstr->env->Invoke("ConvertToRGB32", AVSValue(&res, 1));
				pstr->clp = res.AsClip();
				infh = pstr->clp->GetVideoInfo();

				if (!infh.IsRGB32())
				{
					strncpy_s(pstr->err, ERRMSG_LEN, "Cannot convert video to RGB32", _TRUNCATE);
					return 5;
				}
			}

			if (strcmp("YUY2", cs) == 0 && (!inf.IsYUY2()))
			{
				res = pstr->env->Invoke("ConvertToYUY2", AVSValue(&res, 1));
				pstr->clp = res.AsClip();
				infh = pstr->clp->GetVideoInfo();
				if (!infh.IsYUY2())
				{
					strncpy_s(pstr->err, ERRMSG_LEN, "Cannot convert video to YUY2", _TRUNCATE);
					return 5;
				}
			}

			if (strcmp("YV12", cs) == 0 && (!inf.IsYV12()))
			{
				res = pstr->env->Invoke("ConvertToYV12", AVSValue(&res, 1));
				pstr->clp = res.AsClip();
				infh = pstr->clp->GetVideoInfo();
				if (!infh.IsYV12())
				{
					strncpy_s(pstr->err, ERRMSG_LEN, "Cannot convert video to YV12", _TRUNCATE);
					return 5;
				}
			}
		}

		if (inf.HasAudio())
		{
			*originalSampleType = inf.SampleType();
			if (*originalSampleType != SAMPLE_INT16)
			{
				res = pstr->env->Invoke("ConvertAudioTo16bit", res);
				pstr->clp = res.AsClip();
				infh = pstr->clp->GetVideoInfo();
				if (infh.SampleType() != SAMPLE_INT16)
				{
					strncpy_s(pstr->err, ERRMSG_LEN, "Cannot convert audio to 16bit", _TRUNCATE);
					return 6;
				}
			}
		}

		inf = pstr->clp->GetVideoInfo();
		if (vi != NULL)
		{
			vi->width = inf.width;
			vi->height = inf.height;
			vi->raten = inf.fps_numerator;
			vi->rated = inf.fps_denominator;
			vi->aspectn = 0;
			vi->aspectd = 1;
			vi->interlaced_frame = 0;
			vi->top_field_first = 0;
			vi->num_frames = inf.num_frames;
			vi->pixel_type = inf.pixel_type;

			vi->audio_samples_per_second = inf.audio_samples_per_second;
			vi->num_audio_samples = inf.num_audio_samples;
			vi->sample_type = inf.sample_type;
			vi->nchannels = inf.nchannels;
		}

		pstr->res = new AVSValue(res);

		pstr->err[0] = 0;
		return 0;
	}
	catch (AvisynthError err)
	{
		strncpy_s(pstr->err, ERRMSG_LEN, err.msg, _TRUNCATE);
		return 999;
	}
	catch (...)
	{
		strncpy_s(pstr->err, ERRMSG_LEN, "Unhandled error: dimzon_avs_init", _TRUNCATE);
		return 999;
	}
}

int __stdcall dimzon_avs_init_2(SafeStruct** ppstr, char *func, char *arg, AVSDLLVideoInfo *vi, int* originalPixelType, int* originalSampleType, char *cs)
{
	// same as dimzon_avs_init() but without the fix audio output at 16 bit. New for AviSynth v2.5.7
	SafeStruct* pstr = ((SafeStruct*)malloc(sizeof(SafeStruct)));
	*ppstr = pstr;
	memset(pstr, 0, sizeof(SafeStruct));

	pstr->dll = LoadLibrary("avisynth.dll");
	if (!pstr->dll)
	{
		strncpy_s(pstr->err, ERRMSG_LEN, "Avisynth installation cannot be found", _TRUNCATE);
		return 1;
	}

	IScriptEnvironment* (*CreateScriptEnvironment)(int version) = (IScriptEnvironment*(*)(int)) GetProcAddress(pstr->dll, "CreateScriptEnvironment");
	if (!CreateScriptEnvironment)
	{
		strncpy_s(pstr->err, ERRMSG_LEN, "Cannot load CreateScriptEnvironment", _TRUNCATE);
		return 2;
	}

	pstr->env = CreateScriptEnvironment(AVISYNTH_INTERFACE_VERSION);

	if (pstr->env == NULL)
	{
#if AVISYNTH_INTERFACE_BUILD_VERSION > 4
		strncpy_s(pstr->err, ERRMSG_LEN, "Avisynth 2.6 required", _TRUNCATE);
#else
		strncpy_s(pstr->err, ERRMSG_LEN, "Avisynth 2.5 required", _TRUNCATE);
#endif
		return 3;
	}

#if AVISYNTH_INTERFACE_BUILD_VERSION > 4
	AVS_linkage = pstr->env->GetAVSLinkage(); // AviSynth 2.6 only
#endif

	try
	{
		AVSValue arg(arg);
		AVSValue res = pstr->env->Invoke(func, AVSValue(&arg, 1));
		if (!res.IsClip())
		{
			strncpy_s(pstr->err, ERRMSG_LEN, "The script's return was not a video clip.", _TRUNCATE);
			return 4;
		}
		pstr->clp = res.AsClip();
		VideoInfo inf = pstr->clp->GetVideoInfo();
		VideoInfo infh = pstr->clp->GetVideoInfo();

		if (inf.HasVideo())
		{
			*originalPixelType = inf.pixel_type;

			if (strcmp("RGB24", cs) == 0 && (!inf.IsRGB24()))
			{
				res = pstr->env->Invoke("ConvertToRGB24", AVSValue(&res, 1));
				pstr->clp = res.AsClip();
				infh = pstr->clp->GetVideoInfo();
				if (!infh.IsRGB24())
				{
					strncpy_s(pstr->err, ERRMSG_LEN, "Cannot convert video to RGB24", _TRUNCATE);
					return	5;
				}
			}

			if (strcmp("RGB32", cs) == 0 && (!inf.IsRGB32()))
			{
				res = pstr->env->Invoke("ConvertToRGB32", AVSValue(&res, 1));
				pstr->clp = res.AsClip();
				infh = pstr->clp->GetVideoInfo();
				if (!infh.IsRGB32())
				{
					strncpy_s(pstr->err, ERRMSG_LEN, "Cannot convert video to RGB32", _TRUNCATE);
					return 5;
				}
			}

			if (strcmp("YUY2", cs) == 0 && (!inf.IsYUY2()))
			{
				res = pstr->env->Invoke("ConvertToYUY2", AVSValue(&res, 1));
				pstr->clp = res.AsClip();
				infh = pstr->clp->GetVideoInfo();
				if (!infh.IsYUY2())
				{
					strncpy_s(pstr->err, ERRMSG_LEN, "Cannot convert video to YUY2", _TRUNCATE);
					return 5;
				}
			}

			if (strcmp("YV12", cs) == 0 && (!inf.IsYV12()))
			{
				res = pstr->env->Invoke("ConvertToYV12", AVSValue(&res, 1));
				pstr->clp = res.AsClip();
				infh = pstr->clp->GetVideoInfo();
				if (!infh.IsYV12())
				{
					strncpy_s(pstr->err, ERRMSG_LEN, "Cannot convert video to YV12", _TRUNCATE);
					return 5;
				}
			}
		}

		inf = pstr->clp->GetVideoInfo();
		if (vi != NULL)
		{
			vi->width = inf.width;
			vi->height = inf.height;
			vi->raten = inf.fps_numerator;
			vi->rated = inf.fps_denominator;
			vi->aspectn = 0;
			vi->aspectd = 1;
			vi->interlaced_frame = 0;
			vi->top_field_first = 0;
			vi->num_frames = inf.num_frames;
			vi->pixel_type = inf.pixel_type;

			vi->audio_samples_per_second = inf.audio_samples_per_second;
			vi->num_audio_samples = inf.num_audio_samples;
			vi->sample_type = inf.sample_type;
			vi->nchannels = inf.nchannels;
		}

		pstr->res = new AVSValue(res);

		pstr->err[0] = 0;
		return 0;
	}
	catch (AvisynthError err)
	{
		strncpy_s(pstr->err, ERRMSG_LEN, err.msg, _TRUNCATE);
		return 999;
	}
	catch (...)
	{
		strncpy_s(pstr->err, ERRMSG_LEN, "Unhandled error: dimzon_avs_init_2", _TRUNCATE);
		return 999;
	}
}

// same as dimzon_avs_init_2(), but with a convert to 8 bit if needed (avs+ only)
int __stdcall dimzon_avs_init_3(SafeStruct** ppstr, char *func, char *arg, AVSDLLVideoInfo *vi, int* originalPixelType, int* originalSampleType, char *cs)
{
	SafeStruct* pstr = ((SafeStruct*)malloc(sizeof(SafeStruct)));

	try
	{
		*ppstr = pstr;
		memset(pstr, 0, sizeof(SafeStruct));

		pstr->dll = LoadLibrary("avisynth.dll");
		if (!pstr->dll)
		{
			strncpy_s(pstr->err, ERRMSG_LEN, "Avisynth installation cannot be found", _TRUNCATE);
			return 1;
		}

		IScriptEnvironment* (*CreateScriptEnvironment)(int version) = (IScriptEnvironment*(*)(int)) GetProcAddress(pstr->dll, "CreateScriptEnvironment");
		if (!CreateScriptEnvironment)
		{
			strncpy_s(pstr->err, ERRMSG_LEN, "Cannot load CreateScriptEnvironment", _TRUNCATE);
			return 2;
		}

		pstr->env = CreateScriptEnvironment(AVISYNTH_INTERFACE_VERSION);
		if (pstr->env == NULL)
		{
#if AVISYNTH_INTERFACE_BUILD_VERSION > 4
			strncpy_s(pstr->err, ERRMSG_LEN, "Avisynth 2.6 required", _TRUNCATE);
#else
			strncpy_s(pstr->err, ERRMSG_LEN, "Avisynth 2.5 required", _TRUNCATE);
#endif
			return 3;
		}

#if AVISYNTH_INTERFACE_BUILD_VERSION > 4
		AVS_linkage = pstr->env->GetAVSLinkage(); // AviSynth 2.6 only
#endif

		AVSValue arg(arg);
		AVSValue res = pstr->env->Invoke(func, AVSValue(&arg, 1));
		if (!res.IsClip())
		{
			strncpy_s(pstr->err, ERRMSG_LEN, "The script's return was not a video clip.", _TRUNCATE);
			return 4;
		}

		pstr->clp = res.AsClip();
		VideoInfo inf = pstr->clp->GetVideoInfo();
		VideoInfo infh = pstr->clp->GetVideoInfo();

		if (inf.HasVideo())
		{
			*originalPixelType = inf.pixel_type;

			// convert video only if RGB24 is required
			if (strcmp("RGB24", cs) == 0 && (!inf.IsRGB24()))
			{
				// make sure that the clip is 8 bit
				AVSValue args[2] = { res.AsClip(), 8 };
				res = pstr->env->Invoke("ConvertBits", AVSValue(args, 2));

				// convert to RGB24
				res = pstr->env->Invoke("ConvertToRGB24", res);
				pstr->clp = res.AsClip();
				infh = pstr->clp->GetVideoInfo();
				if (!infh.IsRGB24())
				{
					strncpy_s(pstr->err, ERRMSG_LEN, "Cannot convert video to RGB24", _TRUNCATE);
					return	5;
				}
			}
		}

		inf = pstr->clp->GetVideoInfo();
		if (vi != NULL)
		{
			vi->width = inf.width;
			vi->height = inf.height;
			vi->raten = inf.fps_numerator;
			vi->rated = inf.fps_denominator;
			vi->aspectn = 0;
			vi->aspectd = 1;
			vi->interlaced_frame = 0;
			vi->top_field_first = 0;
			vi->num_frames = inf.num_frames;
			vi->pixel_type = inf.pixel_type;

			vi->audio_samples_per_second = inf.audio_samples_per_second;
			vi->num_audio_samples = inf.num_audio_samples;
			vi->sample_type = inf.sample_type;
			vi->nchannels = inf.nchannels;
		}

		pstr->res = new AVSValue(res);

		pstr->err[0] = 0;
		return 0;
	}
	catch (AvisynthError err)
	{
		strncpy_s(pstr->err, ERRMSG_LEN, err.msg, _TRUNCATE);
		return 999;
	}
	catch (...)
	{
		strncpy_s(pstr->err, ERRMSG_LEN, "Unhandled error: dimzon_avs_init_3", _TRUNCATE);
		return 999;
	}
}