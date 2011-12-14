precision mediump float;
uniform sampler2D sTexture;
uniform sampler2D sMap;

varying vec2 vTextureCoord;
varying vec3 vNormal;
varying vec3 vLightDirection;
varying vec3 vLightReflection;
varying vec3 vViewDirection;
varying vec3 vAmbientColour;

void main() {
  // Texture
  vec4 texColour = texture2D(sTexture, vTextureCoord);
  vec4 texMap = texture2D(sMap, vTextureCoord);
  
  // Ambient
  vec4 ambient = vec4(vAmbientColour, 1.0);
  
  // Diffuse
  vec4 lightDiffuse = vec4(1.0, 1.0, 1.0, 1.0);
  vec3 lightDirection = normalize(vLightDirection);
  vec4 diffuse = max(dot(vNormal, lightDirection), 0.0) * texMap.x * texColour * lightDiffuse;
  
  // Specular
  vec4 lightSpecular = vec4(1.0, 1.0, 1.0, 1.0);
  vec3 lightReflection = normalize(vLightReflection);
  vec3 viewDirection = normalize(vViewDirection);
  vec4 specular = pow(max(dot(lightReflection, viewDirection), 0.0), texMap.z * 255.0) * texMap.y * lightSpecular;
  
  // All
  gl_FragColor = ambient + diffuse + specular;
  //gl_FragColor = vec4(lightDirection, 1.0);
  //gl_FragColor = vec4(lightReflection, 1.0);
  //gl_FragColor = diffuse * vec4(1.0, 1.0, 1.0, 1.0);
  //gl_FragColor = vec4(normalize(vViewDirection), 1.0);
}
