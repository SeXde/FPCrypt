# First approach:

- Contraseña maestra, cada vez que se inicia la aplicación se pide la contraseña maestra y luego nos olvidamos.
- Se pueden gestionar las huellas dactilar y cifrar / descifrar ficheros.
- Mensaje de advertencia al borrar huella.
- Sistema de cifrado: fichero cifrado con la huella + cabecera, que es la huella que se ha utilizado para cifrar el fichero cifrada con AES, cuya clave privada es generada por el programa y es interna del programa.

