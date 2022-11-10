#version 460

layout (location = 0) flat in uint InObjID;

layout (location = 0) out uint outID;

void main() 
{
    outID = InObjID;
}

