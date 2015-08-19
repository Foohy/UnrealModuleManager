//Copyright

#pragma once

class MODULE_NAME_UPPER_API IMODULE_NAMEModule : public IModuleInterface
{
    virtual void StartupModule()  = 0;
    virtual void ShutdownModule() = 0;
    virtual bool IsGameModule() const override
    {
        return false;
    }
};