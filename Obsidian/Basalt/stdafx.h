// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"
#include <string>

#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers

// TODO: reference additional headers your program requires here

namespace basalt {
	std::string FindConjugate(std::string);
}