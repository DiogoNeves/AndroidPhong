uniform mat4 uMVPMatrix;
uniform mat4 uModelViewMatrix;
uniform vec3 uLightPosition;

attribute vec4 aPosition;
attribute vec2 aTextureCoord;

varying vec2 vTextureCoord;
varying vec3 vNormal;
varying vec3 vLightDirection;
varying vec3 vLightReflection;
varying vec3 vViewDirection;
varying vec3 vAmbientColour;

void main() {
  gl_Position = uMVPMatrix * aPosition;
  
  vTextureCoord = aTextureCoord;
  
  vec3 worldPosition = vec3(uModelViewMatrix * aPosition);
  
  vNormal = mat3(uModelViewMatrix) * vec3(0.0, 0.0, -1.0);
  vLightDirection = uLightPosition - worldPosition;
  vLightReflection = -reflect(vLightDirection, vNormal);
  vViewDirection = vec3(0.0, 0.0, 5.0) - worldPosition;
  
  // AmbientReflectivity * AmbientLight
  vAmbientColour = 0.1 * vec3(0.5, 0.05, 0.01);
}
