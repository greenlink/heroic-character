# --- Build Stage ---
FROM node:20 AS build
WORKDIR /app

# Copy package files & install deps
COPY Greenlink.HeroicCharacter.Angular/package*.json ./
RUN npm install

# Copy source and build
COPY Greenlink.HeroicCharacter.Angular/ .
RUN npm run build -- --configuration production

# --- Runtime Stage (Nginx) ---
FROM nginx:1.27
COPY --from=build /app/dist/greenlink-heroic-character-angular/browser /usr/share/nginx/html
COPY Greenlink.HeroicCharacter.Angular/nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
