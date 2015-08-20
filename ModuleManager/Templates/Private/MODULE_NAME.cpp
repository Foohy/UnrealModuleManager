// Copyright ©  All rights reserved

#include "MyModulePrivatePCH.h"
#include "MyModule.h"

class MODULE_NAME_UPPER_API FMODULE_NAMEModule : public IMODULE_NAMEModule
{
    virtual void StartupModule()
    {
        
    }

    virtual void ShutdownModule()
    {
        
    }
};

IMPLEMENT_MODULE(FMODULE_NAMEModule, MODULE_NAME);