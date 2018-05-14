FROM nginx:latest

COPY /PomodoroTimer/bin/Debug/netcoreapp2.0/dist /usr/share/nginx/html
RUN chown -R www-data:www-data /usr/share/nginx/html/
RUN chmod -R 755 /usr/share/nginx/html/

EXPOSE 80

STOPSIGNAL SIGTERM

CMD ["nginx", "-g", "daemon off;"]