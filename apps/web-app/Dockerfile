FROM nginx:alpine

# Create directory for web files (will be mounted as volume)
RUN mkdir -p /usr/share/nginx/html

# Expose port 80
EXPOSE 80

# Start nginx
CMD ["nginx", "-g", "daemon off;"]
